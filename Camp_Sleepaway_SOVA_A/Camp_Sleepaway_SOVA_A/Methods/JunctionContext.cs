
namespace Camp_Sleepaway_SOVA.Methods
{
    public class JunctionContext
    {
        //Skapar ett menyval med en lista av befintliga cabins.
        //Användarens val returneras baserat på ID på val i listan och cabinName
        public static Cabin chooseCabin(CampContext context)
        {
            var cabins = context.Cabins; //Objekt av cabins innehåll

            var cabinNames = cabins.Select(c => c.Name).ToArray(); //Till array

            var cabinChoice = Program.ShowMenu("Välj cabin:", cabinNames); // användaren väljer m.h.a. showmenu

            return cabins.Where(c => c.Name == cabinNames[cabinChoice]).FirstOrDefault();
        }


        //Skapar ett menyval med en lista av befintliga counselors.
        //Användarens val returneras baserat på ID på val i listan och counselorTitles
        public static Counselor chooseCounselor(CampContext context) //Ger oss ett menyval med en lista av alla befintliga counselors
        {
            var counselors = context.Counselors; // Objekt av counselors innehåll

            var counselorTitles = counselors.Select(c => c.Title).ToArray(); // Till array

            var counselorChoice = Program.ShowMenu("Välj counselor:", counselorTitles);//Användaren väljer m.h.a. showmenu

            return counselors.Where(c => c.Title == counselorTitles[counselorChoice]).FirstOrDefault();
        }
    }
}
