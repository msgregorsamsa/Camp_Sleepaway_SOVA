
namespace Camp_Sleepaway_SOVA
{
    public class NextOfKin : Person
    {
        public int Id { get; set; }
        public int CamperId { get; set; }
        public List<Camper> Campers { get; set; } = new(); //Skapar en N-N relation med campers 

    }
}
