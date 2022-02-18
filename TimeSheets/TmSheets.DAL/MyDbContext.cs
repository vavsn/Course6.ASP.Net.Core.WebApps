using Microsoft.EntityFrameworkCore;
using TmSheets.DAL.Models;

namespace TmSheets.DAL
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }

    }
}
