using System.ComponentModel.DataAnnotations;

namespace Camp_Sleepaway_SOVA
{
    public class Camper : Person
    {
        public int Id { get; set; }
        public string? ICE { get; set; } //Nödkontakt

        public Cabin Cabin { get; set; } //Navigation till Cabin, en camper kan ha en stuga

        public int? CabinId { get; set; } //FK får lov att vara null om det inte finns tillräckligt med stugor?

        public List<NextOfKin> NextOfKins { get; set; } = new(); //Skapar en N-N relation med NextOfKin 
                                                                 //eftersom en camper kan ha många nextofkin och en nextofkin kan ha många campers

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public  DateTime Check_In { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Check_Out { get; set; }

    }
}