using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.GameSessions
{
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzDatabase.Data.GameDB _context;

        public DeleteModel(FizzBuzzDatabase.Data.GameDB context)
        {
            _context = context;
        }

        [BindProperty]
        public GameSession GameSession { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamesession = await _context.GameSessions.FirstOrDefaultAsync(m => m.Id == id);

            if (gamesession == null)
            {
                return NotFound();
            }
            else
            {
                GameSession = gamesession;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamesession = await _context.GameSessions.FindAsync(id);
            if (gamesession != null)
            {
                GameSession = gamesession;
                _context.GameSessions.Remove(GameSession);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
