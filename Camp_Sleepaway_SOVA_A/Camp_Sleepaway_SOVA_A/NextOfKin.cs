
using System.ComponentModel.DataAnnotations.Schema;

namespace Camp_Sleepaway_SOVA
{
    public class NextOfKin : Person
    {
        public int Id { get; set; }
        public bool? IsICE { get; set; } //Kontakt som plockas in vid nödsituationer ??

        public int? CamperId { get; set; } //FK får lov att vara null om det inte finns tillräckligt med stugor?

        [ForeignKey("CamperId")] // Annotation för främmande nyckel
        public List<CamperNextOfKin> CamperNextOfKins { get; set; } // Navigationsegenskap

        //public List<Camper> Campers { get; set; } = new(); //Skapar en N-N relation med campers 

    }
}
