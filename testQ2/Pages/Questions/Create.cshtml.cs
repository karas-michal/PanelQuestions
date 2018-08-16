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

namespace testQ2.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly testQ2.Data.ApplicationDbContext _context;
		[BindProperty]
		public int RoomID { get; set; }

        public CreateModel(testQ2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

		public IActionResult OnGet(int id)
        {
			RoomID = id;
            return Page();
        }

		[BindProperty]
        public Question Question { get; set; }
		public async Task<IActionResult> OnPostAsync()
        {
			if (!ModelState.IsValid)
            {
                return Page();
            }
			Question.Room = await _context.Room.FirstOrDefaultAsync(m => m.ID == RoomID);
			Console.WriteLine(Question);
			_context.Question.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}