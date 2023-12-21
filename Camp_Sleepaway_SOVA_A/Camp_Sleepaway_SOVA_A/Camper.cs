using System.ComponentModel.DataAnnotations.Schema;

namespace Camp_Sleepaway_SOVA
{
    public class Camper : Person
    {
        public int Id { get; set; }
        public string? ICE { get; set; } //Nödkontakt

        public int? CabinId { get; set; } //FK får lov att vara null om det inte finns tillräckligt med stugor?

        [ForeignKey("CabinId")] // Annotation för främmande nyckel
        public Cabin Cabin { get; set; } // Navigationsegenskap

        public int? NextOfKinId { get; set; } //FK får lov att vara null om det inte finns tillräckligt med stugor?

        [ForeignKey("NextOfKinId")] // Annotation för främmande nyckel
        public List<CamperNextOfKin> CamperNextOfKins { get; set; } // Navigationsegenskap



        /*public Cabin Cabin { get; set; } //Navigation till Cabin, en camper kan ha en stuga*/

        //public List<NextOfKin> NextOfKins { get; set; } = new(); //Skapar en N-N relation med NextOfKin 
        //eftersom en camper kan ha många nextofkin och en nextofkin kan ha många campers

    }
}