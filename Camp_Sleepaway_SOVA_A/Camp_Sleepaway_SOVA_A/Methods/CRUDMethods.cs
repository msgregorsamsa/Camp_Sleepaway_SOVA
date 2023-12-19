using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class CRUDMethods //Ärver från campcontext för att få åtkomst till connectionstringen?? 
    {
        public static void AddInformation() //Lägg till metod för att lägga till med meny för val av vad man vill lägga till
        {
            Console.WriteLine("");
            string? Name = Console.ReadLine();

            Console.WriteLine("");
            string? Example1 = Console.ReadLine();

            Console.WriteLine("");
            string? Example2 = Console.ReadLine();

            Console.WriteLine("");
            string? Example3 = Console.ReadLine();

            Console.Clear();

            // SQL ska ersättas med LINQ i EF
            NextOfKin c = new NextOfKin()
            {
                DateOfBirth = DateTime.Now,
                FirstName = "Pelle",
                LastName = "Svensson",
                Phone = "07013371337"
            };

            using (var context = new CampContext()) //Lägger till en ny camper
            {
                context.Campers.Add(c);
                context.SaveChanges();
            }
            
        }

        public static void DeleteInformation () //Lägg till metod för att ta bort med meny för val av vad man vill ta bort
        {
            Console.WriteLine("");
            string? Name = Console.ReadLine();

            Console.WriteLine("");
            string? Example1 = Console.ReadLine();

            Console.WriteLine("");
            string? Example2 = Console.ReadLine();

            Console.WriteLine("");
            string? Example3 = Console.ReadLine();

            Console.Clear();

            // SQL ska ersättas med LINQ i EF
        }

        public static void Editinformation() //Lägg till metod för att ändra, med menyval för vad man vill ändra
        {
            Console.WriteLine("");
            string? Name = Console.ReadLine();

            Console.WriteLine("");
            string? Example1 = Console.ReadLine();

            Console.WriteLine("");
            string? Example2 = Console.ReadLine();

            Console.WriteLine("");
            string? Example3 = Console.ReadLine();

            Console.Clear();

            /*using(var context = new CampContext()) //Work in progress!!
{
                // Hämta entiteten som ska uppdateras
                var entitetAttUppdatera = context.Campers.FirstOrDefault(e => e.Id == söktId); 

                if (entitetAttUppdatera != null)
                {
                    // Uppdatera egenskaper
                    entitetAttUppdatera.Property1 = "Nytt värde för egenskap 1";
                    entitetAttUppdatera.Property2 = "Nytt värde för egenskap 2";

                    // Spara ändringar
                    context.SaveChanges();
                }
            }*/
        }

        public static void ShowReportsForCampers() //Lägg till metod för att kunna söka på campers baserat på stuga eller counselor
        {
            Console.WriteLine("");
            string? Name = Console.ReadLine();

            Console.WriteLine("");
            string? Example1 = Console.ReadLine();

            Console.WriteLine("");
            string? Example2 = Console.ReadLine();

            Console.WriteLine("");
            string? Example3 = Console.ReadLine();

            Console.Clear();

            // SQL ska ersättas med LINQ i EF
        }

        public static void ReportsForMissingCouncelor() //Lägg till metod som varnar om en stuga saknar councelors
        {
            Console.WriteLine("");
            string? Name = Console.ReadLine();

            Console.WriteLine("");
            string? Example1 = Console.ReadLine();

            Console.WriteLine("");
            string? Example2 = Console.ReadLine();

            Console.WriteLine("");
            string? Example3 = Console.ReadLine();

            Console.Clear();

            // SQL ska ersättas med LINQ i EF
        }
    }
}
