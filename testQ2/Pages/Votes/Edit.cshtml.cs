using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testQ2.Data;
using testQ2.Models;

namespace testQ2.Pages.Votes
{
    public class EditModel : PageModel
    {
        private readonly testQ2.Data.ApplicationDbContext _context;

        public EditModel(testQ2.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(Vote.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.ID == id);
        }
    }
}
