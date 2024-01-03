
using Microsoft.EntityFrameworkCore;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class JunctionContext
    {
        //Skapar ett menyval med en lista av befintliga cabins.
        public static Cabin chooseCabin(CampContext context)
        {
            var cabins = context.Cabins.Include(c => c.Campers).ToList();
            var cabinInfo = cabins.Select(c => $"{c.Name} ({(c.Campers != null ? c.Campers.Count.ToString() : "0")} campers)").ToArray();
            var cabinChoice = Program.ShowMenu("Välj cabin:", cabinInfo);
            var chosenCabin = cabins.ElementAtOrDefault(cabinChoice);

            if (chosenCabin != null)
            {
                if (chosenCabin.Campers != null && chosenCabin.Campers.Count < 4)
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
