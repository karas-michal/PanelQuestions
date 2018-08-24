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
		public IList<Vote> Votes { get; set; }
		public int[] Scores;

		public async Task OnGetAsync(int id)
		{
			RoomID = id;
			Questions = await _context.Question.Where(r => r.Room.ID == id).ToListAsync();
			Votes = await _context.Vote.Where(r => r.Question.Room.ID == id).ToListAsync();
			Scores = new int[Questions.Count()];
			int count = 0;
			foreach(Question q in Questions)
			{
				foreach(Vote v in Votes)
				{
					if(v.Question.ID == q.ID)
					{
						Scores[count] += v.score;
					}
				}
				count++;
			}
		}
	}
}