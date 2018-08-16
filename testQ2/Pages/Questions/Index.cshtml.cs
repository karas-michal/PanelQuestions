using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testQ2.Data;
using testQ2.Models;

namespace testQ2.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly testQ2.Data.ApplicationDbContext _context;

        public IndexModel(testQ2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
            Question = await _context.Question.ToListAsync();
        }
    }
}
