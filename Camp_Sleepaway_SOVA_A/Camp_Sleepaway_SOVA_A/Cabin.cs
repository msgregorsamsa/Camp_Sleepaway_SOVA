
namespace Camp_Sleepaway_SOVA
{
    public class Cabin 
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<Camper> Campers { get; set; }


        //public int? CounselorId { get; set; } - ta bort denna?
        public Counselor? Counselor { get; set; } = null;

    }
}
