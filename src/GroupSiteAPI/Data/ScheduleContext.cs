using Microsoft.EntityFrameworkCore;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Data
{
    public class ScheduleContext: DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key for UserChoice
            modelBuilder.Entity<UserChoice>().HasKey(e => new { e.UserId, e.SubjectId });
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Schedule> ScheduleItems { get; set; }
        public DbSet<UserChoice> UserChoices { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}