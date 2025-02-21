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
    public class IndexModel : PageModel
    {
        private readonly GameDB _context;

        public IndexModel(GameDB context)
        {
            _context = context;
        }

        public IList<GameRule> GameRuleList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            GameRuleList = await _context.GameRule.ToListAsync();
        }
    }
}