using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.GameRules
{
    public class DeleteModel : PageModel
    {
        private readonly GameDB _context;

        public DeleteModel(GameDB context)
        {
            _context = context;
        }

        [BindProperty]
        public GameRule GameRule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            GameRule = await _context.GameRule.FindAsync(id);

            if (GameRule == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var gameRule = await _context.GameRule.FindAsync(id);

            if (gameRule != null)
            {
                _context.GameRule.Remove(gameRule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}