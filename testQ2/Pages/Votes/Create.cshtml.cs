﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using testQ2.Data;
using testQ2.Models;

namespace testQ2.Pages.Votes
{
    public class CreateModel : PageModel
    {
        private readonly testQ2.Data.ApplicationDbContext _context;

        public CreateModel(testQ2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vote Vote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vote.Add(Vote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}