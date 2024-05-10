using BackEnd.Data;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextResourceController : ControllerBase
    {
        private readonly DataContext _context;

        public TextResourceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TextResource>>> GetAllTextResources()
        {
            var TextResources = await _context.TextResources.ToListAsync();

            return Ok(TextResources);
        }

        [HttpPost]
        public async Task<ActionResult<List<TextResource>>> AddTextResources(TextResource TextResource)
        {
            if (!await _context.Languages.AnyAsync(l => l.Code == TextResource.LanguageCode))
            {
                throw new ArgumentException("Invalid language ID provided");
            }

            _context.TextResources.Add(TextResource);
            await _context.SaveChangesAsync();

            return Ok("Text Resource Added Succesfuly");
        }

        [HttpDelete]
        public async Task<ActionResult<List<TextResource>>> DeleteTextResources(int id)
        {
            var TextResourceToDelete = await _context.TextResources.FindAsync(id);

            if (TextResourceToDelete == null)
            {
                return NotFound("Text Resource not found.");
            }

            _context.TextResources.Remove(TextResourceToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.Write(ex.Message);
                return BadRequest("An error occurred while deleting the Text Resource. See logs for details.");
            }

            return Ok(TextResourceToDelete);
        }
    }
}
