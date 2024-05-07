﻿using BackEnd.Data;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Language>>> GetLanguage(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return BadRequest("Language Not Found");
            }

            return Ok(language);
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
            // 1. Find the language by ID
            var languageToDelete = await _context.Languages.FindAsync(id);

            // 2. Handle non-existent language
            if (languageToDelete == null)
            {
                return NotFound("Language not found.");
            }

            // 3. Perform deletion (optional: handle related entities)
            _context.Languages.Remove(languageToDelete);

            // 4. Save changes and handle potential exceptions
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception and handle appropriately (e.g., return a more informative error message)
                Console.Write(ex.Message);
                return BadRequest("An error occurred while deleting the language. See logs for details.");
            }

            return Ok(languageToDelete);
        }
    }
}
