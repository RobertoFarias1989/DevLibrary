using DevLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevLibrary.Infrastructure.Persistence
{
    public class DevLibraryDbContext : DbContext
    {
        public DevLibraryDbContext(DbContextOptions<DevLibraryDbContext> options) :base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
