using BackEnd.Data;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;

        public ResourceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TextResource>>> GetAllResources()
        {
            var TextResources = await _context.TextResources.ToListAsync();

            return Ok(TextResources);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<TextResource>>> GetResource(int id)
        {
            var TextResource= await _context.Languages.FindAsync(id);
            if (TextResource == null)
            {
                return BadRequest("Text Resource Not Found");
            }

            return Ok(TextResource);
        }

        [HttpPost]
        public async Task<ActionResult<List<TextResource>>> AddResource(TextResource TextResource)
        {
            _context.TextResources.Add(TextResource);
            await _context.SaveChangesAsync();

            return Ok("Text Resource Added Succesfuly");
        }

        [HttpDelete]
        public async Task<ActionResult<List<Language>>> DeleteResource(int id)
        {
            var TextResourceToDelete = await _context.Languages.FindAsync(id);

            if (TextResourceToDelete == null)
            {
                return NotFound("Text Resource not found.");
            }

            _context.Languages.Remove(TextResourceToDelete);

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
