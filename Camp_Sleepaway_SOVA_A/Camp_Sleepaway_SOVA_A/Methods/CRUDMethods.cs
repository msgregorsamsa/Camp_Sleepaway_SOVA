
using Camp_Sleepaway_SOVA.Migrations;
using System.Net;
using System.Numerics;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class CRUDMethods
    {
        //Samtliga Add-metoder
        public static void AddCamper()

        {
            Console.WriteLine("Lägg till en ny Camper:");

            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            var phone = Console.ReadLine();

            Console.Write("E-postadress: ");
            var email = Console.ReadLine();

            Console.Write("Adress: ");
            var address = Console.ReadLine();

            Console.Write("ICE (In Case of Emergency) Tryck 'ENTER' om du ej har någon ICE: ");
            var ice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ice))
            {
                ice = null;
            }

            Console.Write("Födelsedatum (M/d/yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
            {

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

                Console.Clear();
                Console.WriteLine($"Camper {firstName} {lastName} har lagts till i databasen.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ogiltigt datumformat. Camper {firstName} {lastName} kunde inte läggas till.");
            }

        }
        public static void AddCounselor()
        {
            {
                Console.WriteLine("Lägg till en ny Counselor:");

                Console.Write("Förnamn: ");
                var firstName = Console.ReadLine();

                Console.Write("Efternamn: ");
                var lastName = Console.ReadLine();


                Console.Write("Telefonnummer: ");
                var phone = Console.ReadLine();

                Console.Write("E-postadress: ");
                var email = Console.ReadLine();

                Console.Write("Adress: ");
                var address = Console.ReadLine();

                Console.Write("Title: ");
                var title = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("On duty; Ja/Nej: ");
                    string dutyInput = Console.ReadLine(); // Läser in användarens inmatning

                    bool onCabinDuty = false; // Förvalt värde

                    if (dutyInput == "Ja")
                    {
                        onCabinDuty = true;
                    }
                    else if (dutyInput == "Nej")
                    {
                        onCabinDuty = false;
                    }
                    else
                    {
                        Console.WriteLine("Felinmatning. Skriv antingen 'Ja' eller 'nej'");
                        continue;
                    }

                    Console.Write("Födelsedatum (M/d/yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
                    {

                        // Skapa en ny Councelor-instans
                        var newCounselor = new Counselor
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            DateOfBirth = dateOfBirth,
                            Phone = phone,
                            Email = email,
                            Address = address,
                            Title = title,
                            OnCabinDuty = onCabinDuty
                        };

                        // Lägg till i databasen
                        using (var context = new CampContext())
                        {
                            context.Counselors.Add(newCounselor);
                            context.SaveChanges();
                        }

                        Console.Clear();
                        Console.WriteLine($"Counselor {firstName} {lastName} har lagts till i databasen.");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Ogiltigt datumformat. Counselor {firstName} {lastName} kunde inte läggas till.");
                        break;
                    }

                }
            }
        }
        public static void AddNextOfKin()
        {
            Console.WriteLine("Lägg till en ny NextOfKin:");

            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            string lastName = Console.ReadLine();

            Console.Write("Telefonnummer: ");
            string phone = Console.ReadLine();

            Console.Write("E-postadress: ");
            string email = Console.ReadLine();

            Console.Write("Adress: ");
            string address = Console.ReadLine();
            while (true)
            {
                Console.Write("Är du en nödkontakt; Ja/Nej: ");
                string input = Console.ReadLine(); // Läser in användarens inmatning

                bool emergencyContact = false; // Förvalt värde

                if (input == "Ja")
                {
                    emergencyContact = true;
                }
                else if (input == "Nej")
                {
                    emergencyContact = false;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Ange antingen: 'Ja' eller 'Nej'.");

                }
                Console.Write("Födelsedatum (M/d/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateOfBirth))
                {

                    // Skapa ett nytt NextOfKin-objekt
                    var nextOfKin = new NextOfKin
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        IsICE = emergencyContact,
                    };

                    var camper = new Camper();

                    // Lägg till NextOfKin i databasen med Entity Framework
                    using (var context = new CampContext())
                    {
                        context.NextOfKins.Add(nextOfKin);
                        context.SaveChanges();
                    }

                    Console.Clear();
                    Console.WriteLine($"NextOfKin {firstName} {lastName} har lagts till i databasen.");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt datumformat. NextOfKin lades inte till.");
                    break;
                }
            }
        }

        public static void AddCamperWithNextOfKin()
        {
            Console.WriteLine("Camper Name:");
            int camperId = int.Parse(Console.ReadLine());

            Console.WriteLine("Next Of Kin ID:");
            int nextOfKinId = int.Parse(Console.ReadLine());

            using (var context = new CampContext())
            {
                var camper = new Camper { Id = camperId };
                var nextOfKin = context.NextOfKins.Find(nextOfKinId);

                if (nextOfKin != null)
                {
                    // Lägg till den nya Camper i Next Of Kins lista över Campers

                    nextOfKin.Campers.Add(camper);

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Next Of Kin ID not found.");
                }
            }
        }



        public static void AddCabin()
        {
            Console.Write("Ange stugnamn: ");
            string cabinName = Console.ReadLine();

            var newCabin = new Cabin
            {
                Name = cabinName
            };

            using (var context = new CampContext())
            {
                context.Cabins.Add(newCabin);
                context.SaveChanges();
            }

            Console.Clear();
            Console.WriteLine($"{cabinName} har lagts till i databasen.");
        }

        //Samtliga Delete-metoder
        public static void DeleteCamper()
        {
            Console.WriteLine("Ange förnamn på camper du vill ta bort:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på camper du vill ta bort:");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            var camperToRemove = context.Campers
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (camperToRemove != null)
            {
                context.Campers.Remove(camperToRemove);
                context.SaveChanges();
                Console.WriteLine($"Camper {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.WriteLine($"Camper {firstName} {lastName} hittades inte.");
            }
        }

        public static void DeleteCounselor()
        {
            Console.WriteLine("Ange förnamn på den counsolor du vill ta bort:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på den counsolor du vill ta bort:");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            var counselorToRemove = context.Counselors
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (counselorToRemove != null)
            {
                context.Counselors.Remove(counselorToRemove);
                context.SaveChanges();
                Console.WriteLine($"Counselor {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.WriteLine($"Counselor {firstName} {lastName} hittades inte.");
            }
        }

        public static void DeleteNextOfKin()
        {
            Console.WriteLine("Ange förnamn på den Next of Kin du vill ta bort:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn på den Next of Kin du vill ta bort:");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            var nextOfKinToRemove = context.NextOfKins
                .FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);

            if (nextOfKinToRemove != null)
            {
                context.NextOfKins.Remove(nextOfKinToRemove);
                context.SaveChanges();
                Console.WriteLine($"Next Of Kin {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.WriteLine($"Next Of Kin {firstName} {lastName} hittades inte.");
            }
        }

        public static void DeleteCabin()
        {
            Console.WriteLine("Ange namn på den cabin du vill ta bort:");
            var cabinName = Console.ReadLine();
            using var context = new CampContext();

            var cabinToRemove = context.Cabins
                .FirstOrDefault(c => c.Name == cabinName);

            if (cabinToRemove != null)
            {
                // Ta bort camper om den finns
                context.Cabins.Remove(cabinToRemove);
                context.SaveChanges();
                Console.WriteLine($"Cabin {cabinName} har blivit borttagen.");
            }
            else
            {
                Console.WriteLine($"Cabin {cabinName} hittades inte.");
            }
        }

        //Samtliga Edit-metoder

        public static void EditCamper()
        {
            Console.WriteLine("Ange ID för den camper du vill ändra:");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var camper = context.Campers
                .FirstOrDefault(c => c.Id == id);

            if (camper != null)
            {
                Console.WriteLine($"Du ändrar nu: {camper.FirstName} {camper.LastName}, " +
                    $"{camper.DateOfBirth}, {camper.Phone}, {camper.Email}, {camper.Address}, " +
                    $"{camper.ICE}."
                    );

                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");

                Console.WriteLine("Ange nytt förnamn:");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    camper.FirstName = newFirstName;
                }

                Console.WriteLine("Ange nytt efternamn:");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    camper.LastName = newLastName;
                }

                Console.WriteLine("Ange nytt födelsedatum (åååå-mm-dd):");
                string newDateOfBirthInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDateOfBirthInput))
                {
                    if (DateTime.TryParse(newDateOfBirthInput, out DateTime newDateOfBirth))
                    {
                        camper.DateOfBirth = newDateOfBirth;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt datumformat, födelsedatum inte uppdaterat");
                    }
                }

                Console.WriteLine("Ange nytt telefonnummer:");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    camper.Phone = newPhone;
                }

                Console.WriteLine("Ange ny emailadress:");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    camper.Email = newEmail;
                }

                Console.WriteLine("Ange ny adress:");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAddress))
                {
                    camper.Address = newAddress;
                }

                Console.WriteLine("Ange ny ICE-kontakt (id):");
                string newIce = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newIce))
                {
                    camper.ICE = newIce;
                }

                context.SaveChanges();
                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine("Tryck på enter för att återgå till menyn...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Det finns ingen camper med det ID du angivit.");
            }

        }

        public static void EditNextOfKin()
        {
            Console.WriteLine("Ange ID för den närstående du vill ändra:");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var nextOfKin = context.NextOfKins
                .FirstOrDefault(c => c.Id == id);

            if (nextOfKin != null)
            {
                Console.WriteLine($"Du ändrar nu: {nextOfKin.FirstName} {nextOfKin.LastName}, " +
                    $"{nextOfKin.DateOfBirth}, {nextOfKin.Phone}, {nextOfKin.Email}, {nextOfKin.Address}, " +
                    $"{nextOfKin.IsICE}."
                    );

                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");

                Console.WriteLine("Ange nytt förnamn:");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    nextOfKin.FirstName = newFirstName;
                }

                Console.WriteLine("Ange nytt efternamn:");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    nextOfKin.LastName = newLastName;
                }

                Console.WriteLine("Ange nytt födelsedatum (åååå-mm-dd):");
                string newDateOfBirthInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDateOfBirthInput))
                {
                    if (DateTime.TryParse(newDateOfBirthInput, out DateTime newDateOfBirth))
                    {
                        nextOfKin.DateOfBirth = newDateOfBirth;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt datumformat, födelsedatum inte uppdaterat");
                    }
                }

                Console.WriteLine("Ange nytt telefonnummer:");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    nextOfKin.Phone = newPhone;
                }

                Console.WriteLine("Ange ny emailadress:");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    nextOfKin.Email = newEmail;
                }

                Console.WriteLine("Ange ny adress:");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAddress))
                {
                    nextOfKin.Address = newAddress;
                }

                //Console.WriteLine("Uppdatera ICE-status:");
                //string newIsIce = Console.ReadLine();
                //if (!string.IsNullOrWhiteSpace(newIsIce))
                //{
                //    nextOfKin.IsICE = NewIsIce;
                //}

                context.SaveChanges();
                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine("Tryck på enter för att återgå till menyn...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Det finns ingen närstående med det ID du angivit.");
            }
        }


        public static void EditCounselor()
        {
            Console.WriteLine("Ange ID för den ledare du vill ändra:");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var counselor = context.Counselors
                .FirstOrDefault(c => c.Id == id);

            if (counselor != null)
            {
                Console.WriteLine($"Du ändrar nu: {counselor.FirstName} {counselor.LastName}, " +
                    $"{counselor.DateOfBirth}, {counselor.Phone}, {counselor.Email}, {counselor.Address}, " +
                    $"{counselor.Title}, {counselor.OnCabinDuty}."
                    );

                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");

                Console.WriteLine("Ange nytt förnamn:");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    counselor.FirstName = newFirstName;
                }

                Console.WriteLine("Ange nytt efternamn:");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    counselor.LastName = newLastName;
                }

                Console.WriteLine("Ange nytt födelsedatum (åååå-mm-dd):");
                string newDateOfBirthInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDateOfBirthInput))
                {
                    if (DateTime.TryParse(newDateOfBirthInput, out DateTime newDateOfBirth))
                    {
                        counselor.DateOfBirth = newDateOfBirth;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt datumformat, födelsedatum inte uppdaterat");
                    }
                }

                Console.WriteLine("Ange nytt telefonnummer:");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    counselor.Phone = newPhone;
                }

                Console.WriteLine("Ange ny emailadress:");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    counselor.Email = newEmail;
                }

                Console.WriteLine("Ange ny adress:");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAddress))
                {
                    counselor.Address = newAddress;
                }

                Console.WriteLine("Ange ny titel:");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    counselor.Title = newTitle;
                }

                //Console.WriteLine("Ange om personen är ansvarig för någon stuga:");
                //string newCabinDuty = Console.ReadLine();
                //if (!string.IsNullOrWhiteSpace(newCabinDuty))
                //{
                //    counselor.OnCabinDuty = newCabinDuty;
                //}

                context.SaveChanges();
                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine("Tryck på enter för att återgå till menyn...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Det finns ingen närstående med det ID du angivit.");
            }
        }

        public static void EditCabin()
        {
            Console.WriteLine("Ange ID för den stuga du vill ändra:");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var cabin = context.Cabins
                .FirstOrDefault(c => c.Id == id);

            if (cabin != null)
            {
                Console.WriteLine($"Du ändrar nu: {cabin.Name} med cabinID: {cabin.Id}."
                    );

                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");

                Console.WriteLine("Ange nytt namn på stugan: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    cabin.Name = newName;
                }
                
                context.SaveChanges();
                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine("Tryck på enter för att återgå till menyn...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Det finns ingen närstående med det ID du angivit.");
            }

        }


        //Samtliga rapport-metoder
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
