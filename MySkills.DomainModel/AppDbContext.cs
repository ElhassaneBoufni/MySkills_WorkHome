using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySkills.DomainModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faq>()
                    .Property(f => f.id)
                    .ValueGeneratedOnAdd();
        }

        public DbSet<Faq> Faqs { get; set; }

    }
}
