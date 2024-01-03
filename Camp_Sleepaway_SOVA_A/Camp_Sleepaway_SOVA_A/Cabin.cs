
namespace Camp_Sleepaway_SOVA
{
    public class Cabin 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Camper> Campers { get; set; }

        public Counselor? Counselor { get; set; } = null;

    }
}
