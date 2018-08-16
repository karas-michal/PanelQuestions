using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testQ2.Data;
using testQ2.Models;

namespace testQ2.Pages.Votes
{
    public class DeleteModel : PageModel
    {
        private readonly testQ2.Data.ApplicationDbContext _context;

        public DeleteModel(testQ2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vote Vote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vote = await _context.Vote.FirstOrDefaultAsync(m => m.ID == id);

            if (Vote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vote = await _context.Vote.FindAsync(id);

            if (Vote != null)
            {
                _context.Vote.Remove(Vote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
