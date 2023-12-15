
namespace Camp_Sleepaway_SOVA
{
    public class Camper : Person
    {
        public int Id { get; set; }
        public string ICE { get; set; } //Nödkontakt

        public Cabin Cabin { get; set; } //Navigation till Cabin, en camper kan ha en stuga

        public int? CabinId { get; set; } //FK får lov att vara null om det inte finns tillräckligt med stugor?


        //Skapa koppling till cabin_id 
        //Koppling till next of kin 
    }
}
