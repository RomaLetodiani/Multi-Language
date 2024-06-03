using BackEnd.Data;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly DataContext _context;

        public LanguageController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Language>>> GetAllLanguages()
        {
            var languages = await _context.Languages.ToListAsync();

            return Ok(languages);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            var language = await _context.Languages.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        [HttpPost]
        public async Task<ActionResult<List<Language>>> AddLanguage(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLanguage), new { id = language.Id }, language);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Language>>> DeleteLanguage(int id)
        {
            var languageToDelete = await _context.Languages.FindAsync(id);

            if (languageToDelete == null)
            {
                return NotFound("Language not found.");
            }

            _context.Languages.Remove(languageToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.Write(ex.Message);
                return BadRequest("An error occurred while deleting the language. See logs for details.");
            }

            return Ok(languageToDelete);
        }
    }
}
