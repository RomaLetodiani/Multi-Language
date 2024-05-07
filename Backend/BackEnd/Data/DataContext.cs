using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<TextResource> TextResources { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
