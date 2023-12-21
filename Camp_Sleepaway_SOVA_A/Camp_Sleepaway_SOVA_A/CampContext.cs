using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Camp_Sleepaway_SOVA;

public class CampContext : DbContext
{
    public DbSet<Cabin> Cabins { get; set; }
    public DbSet<Camper> Campers { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }
    public DbSet<Counselor> Counselors { get; set; }

    public DbSet <CamperNextOfKin> CamperNextOfKins{ get; set; }


    //add more if we have more tables
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
        modelBuilder.Entity<CamperNextOfKin>()
            .HasKey(cnok => new { cnok.CamperId, cnok.NextOfKinId }); // Anger att kombinationen av CamperId och NextOfKinId är nyckeln

        modelBuilder.Entity<CamperNextOfKin>()
            .HasOne(cnok => cnok.Camper)
            .WithMany(c => c.CamperNextOfKins)
            .HasForeignKey(cnok => cnok.CamperId); // Definierar FK för Camper

        modelBuilder.Entity<CamperNextOfKin>()
            .HasOne(cnok => cnok.NextOfKin)
            .WithMany(n => n.CamperNextOfKins)
            .HasForeignKey(cnok => cnok.NextOfKinId); // Definierar FK för NextOfKin
    }

}
