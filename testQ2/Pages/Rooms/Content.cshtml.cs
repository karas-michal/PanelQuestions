using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testQ2.Models;

namespace testQ2.Pages.Rooms
{
    public class ContentModel : PageModel
    {
		private readonly testQ2.Data.ApplicationDbContext _context;

		public ContentModel(testQ2.Data.ApplicationDbContext context)
		{
			_context = context;
		}
		public int RoomID { get; set; }
		public IList<Question> Questions { get; set; }

		public async Task OnGetAsync(int id)
		{
			RoomID = id;
			Questions = await _context.Question.Where(r => r.Room.ID == id).ToListAsync();
		}
	}
}