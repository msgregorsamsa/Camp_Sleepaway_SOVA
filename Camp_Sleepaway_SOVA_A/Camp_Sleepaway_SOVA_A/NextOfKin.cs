
namespace Camp_Sleepaway_SOVA
{
    public class NextOfKin : Person
    {
        public int Id { get; set; }
        public bool IsICE { get; set; } //Kontakt som plockas in vid nödsituationer ??
        public int NumberOfCampers { get; set; }

        // koppling till camper/s
    }
}
