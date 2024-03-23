using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DayMakerMachine
{
    public class WordContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=words.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().ToTable("Words");
            modelBuilder.Entity<Word>().Property(w => w.Id).HasColumnName("Id");
            modelBuilder.Entity<Word>().Property(w => w.Text).HasColumnName("Text");
            modelBuilder.Entity<Word>().Property(w => w.Category).HasColumnName("Category");
        }
    }
}