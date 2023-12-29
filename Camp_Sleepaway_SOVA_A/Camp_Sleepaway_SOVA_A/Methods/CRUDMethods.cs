
using Microsoft.EntityFrameworkCore;
using System;
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

            using (var context = new CampContext())
            {

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

                var cabinChoice = JunctionContext.chooseCabin(context); // Anropar JunctionContext som presenterar listan med befintliga cabins att välja från 
                Console.WriteLine($"Camper {firstName} {lastName} har tilldelats stuga {cabinChoice.Name}");

                Console.Write("Födelsedatum (M/d/yyyy): ");
                if (DateOnly.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
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
                        CabinName = cabinChoice.Name
                    };

                    Console.Clear();
                    Console.WriteLine($"Camper {firstName} {lastName} har lagts till i databasen.");

                    context.Campers.Add(newCamper);// Lägg till i databasen
                    context.SaveChanges();
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ogiltigt datumformat. Camper {firstName} {lastName} kunde inte läggas till.");
                }
            }

        }

        public static void AddCounselor()
        {
            using (var context = new CampContext())
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

                var cabinChoice = JunctionContext.chooseCabin(context); // Anropar JunctionContext som presenterar listan med befintliga cabins att välja från 
                Console.WriteLine($"Counselor {firstName} {lastName} har tilldelats stuga {cabinChoice.Name}");

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
                    if (DateOnly.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
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
                            CabinName = cabinChoice.Name,
                            Title = title,
                            OnCabinDuty = onCabinDuty
                        };

                        Console.Clear();
                        Console.WriteLine($"Counselor {firstName} {lastName} har lagts till i databasen.");

                        context.Counselors.Add(newCounselor);
                        context.SaveChanges(); // Lägg till i databasen

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
                Console.Write("Födelsedatum (M/d/yyyy): ");
                if (DateOnly.TryParseExact(Console.ReadLine(), "M/d/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly dateOfBirth))
                {

                    // Skapa ett nytt NextOfKin-objekt
                    var nextOfKin = new NextOfKin
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        Phone = phone,
                        Email = email,
                        Address = address
                    };

                    Console.WriteLine("Ange Camper ID för att länka NextOfKin: ");
                    int camperId = int.Parse(Console.ReadLine());

                    using (var context = new CampContext())
                    {
                        var camper = context.Campers.Find(camperId);

                        if (camper != null)
                        {
                            context.NextOfKins.Add(nextOfKin);

                            // Länka NextOfKin till Camper
                            nextOfKin.Campers.Add(camper);

                            context.SaveChanges();

                            Console.Clear();
                            Console.WriteLine($"NextOfKin {firstName} {lastName} har lagts till och länkats till Camper ID: {camperId} i databasen.");
                        }
                        else
                        {
                            Console.WriteLine("Camper ID hittades inte. NextOfKin lades inte till eller länkades.");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt datumformat. NextOfKin lades inte till.");
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

            using var context = new CampContext();
            {
                Console.Write("Ange ID för den camper du vill ändra:");
                int id = int.Parse(Console.ReadLine());

                var camper = context.Campers
                    .FirstOrDefault(c => c.Id == id);

                if (camper != null)
                {
                    Console.WriteLine($"Du ändrar nu: {camper.FirstName} {camper.LastName}, " +
                        $"{camper.DateOfBirth}, {camper.Phone}, {camper.Email}, {camper.Address}");

                    Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");

                    Console.Write("Ange nytt förnamn:");
                    string newFirstName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newFirstName))
                    {
                        camper.FirstName = newFirstName;
                    }

                    Console.Write("Ange nytt efternamn:");
                    string newLastName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        camper.LastName = newLastName;
                    }

                    Console.Write("Ange nytt födelsedatum (åååå-mm-dd):");
                    string newDateOfBirthInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDateOfBirthInput))
                    {
                        if (DateOnly.TryParse(newDateOfBirthInput, out DateOnly newDateOfBirth))
                        {
                            camper.DateOfBirth = newDateOfBirth;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt datumformat, födelsedatum inte uppdaterat");
                        }
                    }

                    Console.Write("Ange nytt telefonnummer:");
                    string newPhone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone))
                    {
                        camper.Phone = newPhone;
                    }

                    Console.Write("Ange ny emailadress:");
                    string newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail))
                    {
                        camper.Email = newEmail;
                    }

                    Console.Write("Ange ny adress:");
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress))
                    {
                        camper.Address = newAddress;
                    }

                    Console.Write("Vill du byta stuga? Ja/Nej: ");
                    string changeCabinChoice = Console.ReadLine();
                    if (changeCabinChoice == "Ja" || changeCabinChoice == "ja")
                    {
                        Console.WriteLine("Välj en ny stuga");
                        var cabinChoice = JunctionContext.chooseCabin(context); // Anropar JunctionContext som presenterar listan med befintliga cabins att välja från 

                        camper.Cabin = cabinChoice;

                        Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} har bytt till stuga {cabinChoice.Name}");
                    }

                    else if (changeCabinChoice == "Nej" || changeCabinChoice == "nej")
                    {
                        Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} bor kvar i samma stuga");
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
                    $"{nextOfKin.DateOfBirth}, {nextOfKin.Phone}, {nextOfKin.Email}, {nextOfKin.Address}");

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
                    if (DateOnly.TryParse(newDateOfBirthInput, out DateOnly newDateOfBirth))
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
                    if (DateOnly.TryParse(newDateOfBirthInput, out DateOnly newDateOfBirth))
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

                Console.WriteLine("Vill du byta stuga? Ja/Nej: ");
                string changeCabinChoice = Console.ReadLine();
                if (changeCabinChoice == "Ja" || changeCabinChoice == "ja")
                {
                    Console.WriteLine("Välj en ny stuga");
                    var cabinChoice = JunctionContext.chooseCabin(context); // Anropar JunctionContext som presenterar listan med befintliga cabins att välja från 

                    counselor.Cabin = cabinChoice;

                    Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} har bytt till stuga {cabinChoice.Name}");
                }

                else if (changeCabinChoice == "Nej" || changeCabinChoice == "nej")
                {
                    Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} bor kvar i samma stuga");
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
                Console.WriteLine("Det finns ingen counselor med det namn du angivit.");
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
        public static void ReportsForCampers() //Lägg till metod för att kunna söka på campers baserat på stuga eller counselor
        {
            Console.Clear();

            using (var context = new CampContext())
            {
                bool running = true;
                while (running)
                {
                    int option = Program.ShowMenu("Välj en sökkriterie för din rapport:", new[]
                    {
                    "Sortera rapport baserat på Cabin",
                    "Sortera rapport baserat på Counselor",
                    "Återgå"
                    });

                    Console.Clear();

                    if (option == 0) //Visa campers baserat på cabin
                    {
                        Console.WriteLine("Ange stugnamn för att visa campers:");
                        string cabinName = (Console.ReadLine());

                        var campersInCabin = context.Campers
                            .Where(c => c.CabinName == cabinName)
                            .ToList();

                        if (campersInCabin.Any())
                        {
                            foreach (var camper in campersInCabin)
                            {
                                Console.WriteLine($"Camper: {camper.FirstName} {camper.LastName}");
                            }
                            Console.WriteLine(); //Blankrad
                        }
                        else
                        {
                            Console.WriteLine("Inga campers hittades i den angivna stugan.");
                        }
                    }

                    else if (option == 1) //Visa campers baserat på counselor
                    {
                        Console.WriteLine("Ange förnamn på önskad stugansvarig för att visa campers:");
                        string counselorFirstName = Console.ReadLine();

                        Console.WriteLine("Ange efternamn på önskad stugansvarig för att visa campers:");
                        string counselorLastName = Console.ReadLine();

                        Counselor? counselor = context.Counselors.Where(c => c.FirstName == counselorFirstName && c.LastName == counselorLastName).FirstOrDefault();

                        if (counselor == null)
                        {
                            Console.WriteLine("Det finns ingen stugansvarig med angivet namn.");
                            return;
                        }

                        var counselorsCabin = counselor.CabinName;
                        if (counselorsCabin == null)
                        {
                            Console.WriteLine($"Stugansvarig med namn {counselorFirstName} {counselorLastName} är för tillfället inte tilldelad någon stuga");
                            return;
                        }

                        var campersWithCounselor = context.Campers.Where(c => c.CabinName == counselorsCabin).ToList();
                        if (!campersWithCounselor.Any())
                        {
                            Console.WriteLine("Angiven stugansvarig är tilldelad en stuga men stugan innehåller inte några campers.");
                            return;
                        }

                        foreach (var camper in campersWithCounselor)
                        {
                            Console.WriteLine($"Camper: {camper.FirstName} {camper.LastName}");
                        }

                        //var cabinsWithoutCounselor = context.Cabins.Where(cabin => cabin.Counselor == null).ToList();

                        List<Cabin> cabinsWithoutCounselor = new List<Cabin>();
                        foreach (var cabin in context.Cabins)
                        {
                            if (cabin.Counselor == null)
                            {
                                cabinsWithoutCounselor.Add(cabin);
                            }
                        }

                        if (cabinsWithoutCounselor.Any())
                        {
                            //Skapar en röd varningstext
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Varning! Följande stugor saknar en stugansvarig:");
                            foreach (var cabin in cabinsWithoutCounselor)
                            {
                                Console.WriteLine($"Stuga ID: {cabin.Id} - Namn: {cabin.Name}");
                            }
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        running = false; //Återgår till föregående meny
                    }
                }
            }
        }

        public static void ReportForCampersWithNOK()
        {
            {
                using (CampContext context = new CampContext())
                {
                    var campersWithNextOfKin = context.Campers
                        .Include(c => c.NextOfKins)
                        .Where(c => c.NextOfKins.Any())
                        .OrderBy(c => c.CabinName)
                        .ToList();
                    Console.Clear();

                    const int camperColumnWidth = 25;
                    const int nextOfKinColumnWidth = 25;
                    const int cabinColumnWidth = 15;

                    Console.WriteLine($"{"CAMPER".PadRight(camperColumnWidth)}{"NEXTOFKIN".PadRight(nextOfKinColumnWidth)}{"CABIN".PadRight(cabinColumnWidth)}");
                    Console.WriteLine(new string('-', camperColumnWidth + nextOfKinColumnWidth + cabinColumnWidth));

                    foreach (var camper in campersWithNextOfKin)
                    {
                        Console.Write($"{camper.FirstName} {camper.LastName}".PadRight(camperColumnWidth));

                        if (camper.NextOfKins.Any())
                        {
                            Console.Write($"{camper.NextOfKins[0].FirstName} {camper.NextOfKins[0].LastName}".PadRight(nextOfKinColumnWidth));
                        }
                        else
                        {
                            Console.Write($"{"".PadRight(nextOfKinColumnWidth)}");
                        }

                        Console.WriteLine($"{camper.CabinName}".PadRight(cabinColumnWidth));
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
