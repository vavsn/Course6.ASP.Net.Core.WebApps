using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TmSheets.DAL
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {

        MyDbContext IDesignTimeDbContextFactory<MyDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MyDbContext>();
            //var connectionString = configuration.GetConnectionString("Data Source=DbPersons");

            builder.UseSqlite("Data Source=DbPersons");

            return new MyDbContext(builder.Options);
        }
    }
}
