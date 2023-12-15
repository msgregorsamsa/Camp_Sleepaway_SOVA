

using Microsoft.EntityFrameworkCore;

namespace Camp_Sleepaway_SOVA
{
    public class CampContext : DbContext
    {
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        
        //add more if we have more tables
    }
}
