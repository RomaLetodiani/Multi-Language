using BackEnd.Data;
using BackEnd.dtos;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly DataContext _context;

        public PageController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Page>>> GetAllPages()
        {
            var Pages = await _context.Pages.ToListAsync();

            return Ok(Pages);
        }

        [HttpPost]
        public async Task<ActionResult<List<Page>>> AddPage(PageDto page)
        {
            var Page = new Page
            {
                Name = page.Name,
                Pathname = page.Pathname

            };
            _context.Pages.Add(Page);
            await _context.SaveChangesAsync();

            return Ok("Page Added Succesfuly");
        }

        [HttpDelete]
        public async Task<ActionResult<List<Page>>> DeletePage(int[] ids)
        {

            foreach (var id in ids)
            {
                var pageToDelete = await _context.Pages.FindAsync(id);

                if (pageToDelete == null)
                {
                    return BadRequest("Invalid Page id");
                };
                if (pageToDelete != null)
                {
                    // Page found, proceed with deletion
                    _context.Pages.Remove(pageToDelete);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Pages Deleted Succesfully");
            }
            catch (DbUpdateException ex)
            {
                Console.Write(ex.Message);
                return BadRequest("An error occurred while deleting the page. See logs for details.");
            }
        }

        [HttpGet("{pathname}/textresources")]
        public async Task<ActionResult<Dictionary<string, string>>> GetPageTextResources(string pathname, string languageCode)
        {
            var page = await _context.Pages
                .Include(p => p.PageTextResource)
                    .ThenInclude(ptr => ptr.TextResource)
                        .ThenInclude(tr => tr.Language)
                .FirstOrDefaultAsync(p => p.Pathname == pathname);

            if (page == null)
            {
                return NotFound();
            }

            var textResources = page.PageTextResource
                .Where(ptr => ptr.TextResource.Language.Code == languageCode)
                .ToDictionary(ptr => ptr.TextResource.Key, ptr => ptr.TextResource.Text);

            return textResources;
        }
    }
}
