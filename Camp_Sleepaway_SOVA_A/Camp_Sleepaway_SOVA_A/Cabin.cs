
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Camp_Sleepaway_SOVA
{
    public class Cabin 
    {
        public int Id { get; set; }
        public string Name { get; set; } //Stugnamn

        public List<Camper> Campers { get; set; } // ändrar till lista

        //public int? CounselorId { get; set; } // FK till ledare, kan vara null om ingen ledare är kopplad till stugan

        public Counselor? Counselor { get; set; } = null; // Navigation property till Counselor, virtual - men varför?

        public List<Stay> Stays { get; set; } = new();



        // Skapa koppling /public camper reference) till Camper - public  int Occupants { get; set; }

    }
}
