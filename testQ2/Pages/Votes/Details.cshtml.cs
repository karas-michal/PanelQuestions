﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly testQ2.Data.ApplicationDbContext _context;

        public DetailsModel(testQ2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
