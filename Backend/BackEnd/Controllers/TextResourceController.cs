using BackEnd.Data;
using BackEnd.dtos;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TextResource>> GetTextResource(int id)
        {
            var textResource = await _context.TextResources.FindAsync(id);

            if (textResource == null)
            {
                return NotFound();
            }

            return textResource;
        }

        [HttpPost]
        public async Task<ActionResult<TextResource>> CreateTextResource(TextResourceDto textResourceDto)
        {
            var textResource = new TextResource
            {
                Key = textResourceDto.Key,
                Text = textResourceDto.Text,
                LanguageId = textResourceDto.LanguageId,
                Language = await _context.Languages.FindAsync(textResourceDto.LanguageId)
            };
            _context.TextResources.Add(textResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTextResource), new { id = textResource.Id }, textResource);
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
