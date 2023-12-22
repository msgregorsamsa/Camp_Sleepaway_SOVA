
using System.ComponentModel.DataAnnotations;

namespace Camp_Sleepaway_SOVA
{
    public class Counselor : Person
    {
        public int Id { get; set; }

        public string Title { get; set; } //Åldersgrupp?

        public bool OnCabinDuty { get; set; } //Det finns fler stugor än councelors, därav kommer vissa inte ha någon stuga att ansvara över

        public int? CabinId { get; set; } // FK till Cabin, kan vara null om ledaren inte är knuten till en stuga

        public virtual Cabin Cabin { get; set; } // Navigation property till Cabin

        public List<Stay> Stays { get; set; } = new();


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Check_In { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Check_Out { get; set; }

    }
}

