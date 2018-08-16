using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testQ2.Models;

namespace testQ2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<testQ2.Models.Room> Room { get; set; }
        public DbSet<testQ2.Models.Question> Question { get; set; }
        public DbSet<testQ2.Models.Vote> Vote { get; set; }
    }
}
