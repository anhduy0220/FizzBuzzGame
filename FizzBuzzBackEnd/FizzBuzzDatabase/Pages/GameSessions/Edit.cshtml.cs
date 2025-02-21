using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Pages.GameSessions
{
    public class EditModel : PageModel
    {
        private readonly GameDB _context;

        public EditModel(GameDB context)
        {
            _context = context;
        }

        [BindProperty]
        public GameSession GameSession { get; set; }

        public IActionResult OnGet(int id)
        {
            GameSession = _context.GameSessions
                .Include(gs => gs.Game)
                .Include(gs => gs.Player)
                .FirstOrDefault(gs => gs.Id == id);

            if (GameSession == null)
            {
                return NotFound();
            }

            ViewData["GameId"] = new SelectList(_context.Games, "Id", "GameName");
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GameSession).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
