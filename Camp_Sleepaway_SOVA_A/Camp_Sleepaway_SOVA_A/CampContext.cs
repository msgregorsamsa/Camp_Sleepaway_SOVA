using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Camp_Sleepaway_SOVA;

public class CampContext : DbContext
{
    public static DbSet<Cabin> Cabins { get; set; }
    public static DbSet<Camper> Campers { get; set; }
    public static DbSet<NextOfKin> NextOfKins { get; set; }
    public static DbSet<Counselor> Counselors { get; set; }

    //add more if we have more tables
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var connectionString = configuration.GetConnectionString("local");

        optionsBuilder.UseSqlServer(connectionString)
            .LogTo(Console.WriteLine,
            new[] { DbLoggerCategory.Database.Name },
            LogLevel.Information)
            .EnableSensitiveDataLogging();

    }
}  
