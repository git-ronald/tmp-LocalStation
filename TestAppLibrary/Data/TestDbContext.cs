using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestAppLibrary.Data.Models;

namespace TestAppLibrary.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<Dummy> Dummies => Set<Dummy>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "test.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}
