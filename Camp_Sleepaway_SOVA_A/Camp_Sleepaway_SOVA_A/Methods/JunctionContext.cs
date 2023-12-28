﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class JunctionContext
    {
        public static Cabin chooseCabin(CampContext context) //Ger oss ett menyval med en lista av alla befintliga cabins
        {
            // Skapar ett object av Cabins innehåll
            var cabins = context.Cabins;
            // Gör en array av alla namnen
            var cabinNames = cabins.Select(c => c.Name).ToArray();
            // Få användaren att välja en av dem
            var cabinChoice = Program.ShowMenu("Välj cabin:", cabinNames);
            // Använd användarens val till att hitta rätt object, välj sedan ID från detta objektet och retunera bara första av dem (utifall vi har fler cabins som heter samma)
            return cabins.Where(c => c.Name == cabinNames[cabinChoice]).FirstOrDefault();
        }

        public static Counselor chooseCounselor(CampContext context) //Ger oss ett menyval med en lista av alla befintliga counselors
        {
            // Skapar ett object av Cabins innehåll
            var counselors = context.Counselors;
            // Gör en array av alla namnen
            var counselorTitles = counselors.Select(c => c.Title).ToArray();
            // Få användaren att välja en av dem
            var counselorChoice = Program.ShowMenu("Välj counselor:", counselorTitles);
            // Använd användarens val till att hitta rätt object, välj sedan ID från detta objektet och retunera bara första av dem (utifall vi har fler cabins som heter samma)
            return counselors.Where(c => c.Title == counselorTitles[counselorChoice]).FirstOrDefault();
        }
    }
}
