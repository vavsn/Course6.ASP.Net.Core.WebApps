using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL
{
    public class MyDbContext : DbContext
    {
        //<MyDbContext>
        public MyDbContext(DbContextOptions options) : base(options) { }
        //        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Employee>();
        }

    }
}
