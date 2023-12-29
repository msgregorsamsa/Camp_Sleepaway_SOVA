using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Camp_Sleepaway_SOVA;

public class CampContext : DbContext
{
    public CampContext() : base()
    {
        foreach(var counselor in Counselors.ToList())
        {
            var cabin = Cabins.Where(c => c.Name == counselor.CabinName).FirstOrDefault();
            cabin.Counselor = counselor;
        }
    }

    public DbSet<Cabin> Cabins { get; set; }
    public DbSet<Camper> Campers { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }
    public DbSet<Counselor> Counselors { get; set; }
    public DbSet<Stay> Stays { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var connectionString = configuration.GetConnectionString("local");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camper>()
            .HasMany(c => c.NextOfKins)
            .WithMany(n => n.Campers)
            .UsingEntity(junction => junction.ToTable("Campers_NextOfKins"));
    }
}  
