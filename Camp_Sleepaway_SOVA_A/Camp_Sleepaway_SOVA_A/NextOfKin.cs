
using System.ComponentModel.DataAnnotations.Schema;

namespace Camp_Sleepaway_SOVA
{
    public class NextOfKin : Person
    {
        public int Id { get; set; }

        [NotMapped]
        public int CamperId { get; set; }
        public List<Camper> Campers { get; set; } = new(); 

    }
}
