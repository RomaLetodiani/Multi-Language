using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<TextResource> TextResources { get; set; }
        public DbSet<PageTextResource> PageTextResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PageTextResource>()
                .HasKey(pt => new { pt.PageId, pt.TextResourceId });

            modelBuilder.Entity<PageTextResource>()
                .HasOne(pt => pt.Page)
                .WithMany(p => p.PageTextResource)
                .HasForeignKey(pt => pt.PageId);

            modelBuilder.Entity<PageTextResource>()
                .HasOne(pt => pt.TextResource)
                .WithMany(tr => tr.PageTextResource)
                .HasForeignKey(pt => pt.TextResourceId);

            modelBuilder.Entity<TextResource>()
                .HasOne(tr => tr.Language)
                .WithMany()
                .HasForeignKey(tr => tr.LanguageId);
        }
    }
}
