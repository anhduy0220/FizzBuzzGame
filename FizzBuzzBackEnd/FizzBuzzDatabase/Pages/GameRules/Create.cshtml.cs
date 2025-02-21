using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.GameRules
{
    public class CreateModel : PageModel
    {
        private readonly GameDB _context;

        public CreateModel(GameDB context)
        {
            _context = context;
        }

        [BindProperty]
        public GameRule GameRule { get; set; } = new GameRule();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameRule.Add(GameRule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}