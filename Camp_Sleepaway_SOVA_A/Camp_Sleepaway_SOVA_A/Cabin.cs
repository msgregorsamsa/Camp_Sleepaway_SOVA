
namespace Camp_Sleepaway_SOVA
{
    public class Cabin 
    {
        public int Id { get; set; }
        public string Name { get; set; } //Stugnamn

        public int BedNumber { get; set; }

        public  DateTime Check_In { get; set; } 

        public DateTime Check_Out { get; set; }

        // Skapa koppling /public camper reference) till Camper - public  int Occupants { get; set; }

    }
}
