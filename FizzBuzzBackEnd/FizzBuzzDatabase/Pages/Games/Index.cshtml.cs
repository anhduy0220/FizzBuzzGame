using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameDB _context;

        public IndexModel(GameDB context)
        {
            _context = context;
        }

        public IList<Game> Games { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Games != null)
            {
                Games = await _context.Games.ToListAsync();
            }
        }
    }
}
