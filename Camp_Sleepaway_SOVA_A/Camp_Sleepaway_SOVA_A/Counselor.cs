
namespace Camp_Sleepaway_SOVA
{
    public class Counselor : Person
    {
        public int Id { get; set; }

        public string Title { get; set; } //Åldersgrupp?

        public string InChargeOf { get; set; } //Ansvarsområde

        public bool OnCabinDuty { get; set; } //Det finns fler stugor än councelors, därav kommer vissa inte ha någon stuga att ansvara över

        public int? CabinId { get; set; } // FK till Cabin, kan vara null om ledaren inte är knuten till en stuga

        public virtual Cabin Cabin { get; set; } // Navigation property till Cabin
    }
    //Koppling till campers ? Genom cabin?
}

