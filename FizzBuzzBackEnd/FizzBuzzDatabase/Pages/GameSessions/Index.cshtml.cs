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
    public class IndexModel : PageModel
    {
        private readonly GameDB _context;

        public IndexModel(GameDB context)
        {
            _context = context;
        }

        public IList<GameSession> GameSessions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GameSessions != null)
            {
                GameSessions = await _context.GameSessions
                    .Include(gs => gs.Game)
                    .Include(gs => gs.Player)
                    .ToListAsync();
            }
        }
    }
}
