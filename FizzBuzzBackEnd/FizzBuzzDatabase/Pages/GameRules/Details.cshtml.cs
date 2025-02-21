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
    public class DetailsModel : PageModel
    {
        private readonly GameDB _context;

        public DetailsModel(GameDB context)
        {
            _context = context;
        }

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
    }
}
