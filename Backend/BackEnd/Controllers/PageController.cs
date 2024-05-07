﻿using BackEnd.Data;
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
        public async Task<ActionResult<List<Page>>> AddPage(Page Page)
        {
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
    }
}