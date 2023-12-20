using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class CRUDMethods 
    {
        public static void AddingOptions()
        {
            AddCamper();
        }
        public static void AddCamper()

        {
            Console.WriteLine("Lägg till en ny Camper:");

            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Födelsedatum (M/d/yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
            {
                Console.Write("Telefonnummer: ");
                var phone = Console.ReadLine();

                Console.Write("E-postadress: ");
                var email = Console.ReadLine();

                Console.Write("Adress: ");
                var address = Console.ReadLine();

                Console.Write("ICE (In Case of Emergency): ");
                var ice = Console.ReadLine();

                // Skapa en ny Camper-instans
                var newCamper = new Camper
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Phone = phone,
                    Email = email,
                    Address = address,
                    ICE = ice
                };

                // Lägg till i databasen
                using (var context = new CampContext())
                {
                    context.Campers.Add(newCamper);
                    context.SaveChanges();
                }

                Console.WriteLine($"Camper {firstName} {lastName} har lagts till i databasen.");
            }
            else
            {
                Console.WriteLine($"Ogiltigt datumformat. Camper {firstName} {lastName} kunde inte läggas till.");
            }

        }

        public static void DeleteInformation() //Lägg till metod för att ta bort med meny för val av vad man vill ta bort
        {
            Console.WriteLine("Ange förnamn på camper att ta bort:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på camper att ta bort:");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            // Hitta campers baserat på förnamn och efternamn
            var camperToRemove = context.Campers
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (camperToRemove != null)
            {
                // Ta bort camper om den finns
                context.Campers.Remove(camperToRemove);
                context.SaveChanges();
                Console.WriteLine($"Camper {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.WriteLine($"Camper {firstName} {lastName} hittades inte.");
            }
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
