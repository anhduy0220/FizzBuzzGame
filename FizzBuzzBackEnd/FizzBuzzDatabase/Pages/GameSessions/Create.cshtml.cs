using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.GameSessions
{
    public class CreateModel : PageModel
    {
        private readonly GameDB _context;

        public CreateModel(GameDB context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "GameName");
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public GameSession GameSession { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameSessions.Add(GameSession);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
