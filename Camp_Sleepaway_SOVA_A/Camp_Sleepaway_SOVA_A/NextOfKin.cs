
namespace Camp_Sleepaway_SOVA
{
    public class NextOfKin : Person
    {
        public int Id { get; set; }
        public bool IsICE { get; set; } //Kontakt som plockas in vid nödsituationer ??
        public int NumberOfCampers { get; set; }

        public Camper Camper { get; set; } // Navigation reference till Camper

        public List<Camper> Campers { get; set; } = new(); //skapar en N-N relation med campers 
        //eftersom en camper kan ha många nextofkin och en nextofkin kan ha många campers

        
    }
}
