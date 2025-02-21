using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly GameDB _context;

        public IndexModel(GameDB context)
        {
            _context = context;
        }

        public IList<Player> Players { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                Players = await _context.Players.ToListAsync();
            }
        }
    }
}
