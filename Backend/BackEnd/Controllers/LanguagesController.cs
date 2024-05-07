using BackEnd.Data;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly DataContext _context;

        public LanguagesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Language>>> GetAllLanguages()
        {
            var languages = await _context.Languages.ToListAsync();

            return Ok(languages);
        }

        [HttpPost]
        public async Task<ActionResult<List<Language>>> AddLanguage(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return Ok("Language Added Succesfuly");
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
