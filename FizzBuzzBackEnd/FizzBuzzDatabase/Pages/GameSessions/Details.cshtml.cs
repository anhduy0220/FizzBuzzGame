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
    public class DetailsModel : PageModel
    {
        private readonly GameDB _context;

        public DetailsModel(GameDB context)
        {
            _context = context;
        }

        public GameSession GameSession { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_context.GameSessions == null)
            {
                return NotFound();
            }

            var gamesession = await _context.GameSessions
                .Include(gs => gs.Game)
                .Include(gs => gs.Player)
                .FirstOrDefaultAsync(m => m.Id == id);

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
    }
}
