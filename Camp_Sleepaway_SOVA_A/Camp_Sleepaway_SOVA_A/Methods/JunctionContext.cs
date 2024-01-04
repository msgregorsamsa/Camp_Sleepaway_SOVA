
using Microsoft.EntityFrameworkCore;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class JunctionContext
    {
        //Skapar ett menyval med en lista av befintliga cabins samt hur många campers som bor i varje cabin
        public static Cabin chooseCabin(CampContext context)
        {
            var cabins = context.Cabins.Include(c => c.Campers).ToList();
            var counselors = context.Counselors.ToList(); // Exkludera CabinName här

            var cabinInfo = cabins.Select(c =>
            {
                var counselorsForCabin = counselors.Count(cc => cc.CabinName == c.Name);
                return $"{c.Name} ({(c.Campers != null ? c.Campers.Count.ToString() : "0")} campers, {counselorsForCabin} counselors)";
            }).ToArray();

            var cabinChoice = Program.ShowMenu("Välj stuga:", cabinInfo);
            Console.Clear();
            var chosenCabin = cabins.ElementAtOrDefault(cabinChoice);

            if (chosenCabin != null)
            {
                // Hämta counselors för den valda stugan
                var counselorsForChosenCabin = counselors.Where(c => c.CabinName == chosenCabin.Name).ToList();

                if (chosenCabin.Campers != null && chosenCabin.Campers.Count < 4 && counselorsForChosenCabin.Any())
                {
                    return chosenCabin;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }


        //Skapar ett menyval med en lista av befintliga counselors.
        public static Counselor chooseCounselor(CampContext context) //Ger oss ett menyval med en lista av alla befintliga counselors
        {
            var counselors = context.Counselors; // Objekt av counselors innehåll

            var counselorTitles = counselors.Select(c => c.Title).ToArray(); // Till array

            var counselorChoice = Program.ShowMenu("Välj counselor:", counselorTitles);//Användaren väljer m.h.a. showmenu

            return counselors.Where(c => c.Title == counselorTitles[counselorChoice]).FirstOrDefault();
        }
    }
}
