using Microsoft.EntityFrameworkCore;
using MySkills.Domain.Entities;
//using MySkills.Persistence.Configurations;

namespace MySkills.Persistence
{
    public class MySkillsDbContext : DbContext
    {
        public MySkillsDbContext(DbContextOptions<MySkillsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySkillsDbContext).Assembly);
        }
    }
}
