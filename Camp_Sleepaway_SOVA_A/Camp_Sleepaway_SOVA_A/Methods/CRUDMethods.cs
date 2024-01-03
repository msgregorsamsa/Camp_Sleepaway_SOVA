
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
                Console.WriteLine($"Camper {firstName} {lastName} har blivit tilldelad cabin med namn {cabinChoice.Name}");

                Console.Write("Ange incheckningsdatum (yyyy-mm-dd) Tryck 'ENTER' för att ej ange ett datum: ");
                string inputCheckIn = Console.ReadLine();
                DateOnly? checkIn = !string.IsNullOrWhiteSpace(inputCheckIn) ?
                    DateOnly.TryParseExact(inputCheckIn, "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out var parsedCheckIn) ?
                    parsedCheckIn : (DateOnly?)null : null;

                Console.Write("Ange utcheckningsdatum (yyyy-mm-dd) Tryck 'ENTER' för att ej ange ett datum: ");
                string inputCheckOut = Console.ReadLine();
                DateOnly? checkOut = !string.IsNullOrWhiteSpace(inputCheckOut) ?
                    DateOnly.TryParseExact(inputCheckOut, "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out var parsedCheckOut) ?
                    parsedCheckOut : (DateOnly?)null : null;

                Console.Write("Födelsedatum (yyyy-mm-dd): ");
                if (DateOnly.TryParseExact(Console.ReadLine(), "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
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
                        CabinName = cabinChoice.Name,
                        Check_In = checkIn,
                        Check_Out = checkOut

                    };

                    Console.Clear();
                    Console.WriteLine($"Camper {firstName} {lastName} har blivit tillagd.");

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
                Console.WriteLine($"Counselor {firstName} {lastName} har blivit tilldelad cabin med namn {cabinChoice.Name}.");

                Console.Write($"Ange startdatum som du är ansvarig över {cabinChoice.Name} (Tryck 'ENTER' för att ej ange ett datum: ");
                string inputCheckIn = Console.ReadLine();
                DateOnly? checkIn = !string.IsNullOrWhiteSpace(inputCheckIn) ?
                    DateOnly.TryParseExact(inputCheckIn, "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out var parsedCheckIn) ?
                    parsedCheckIn : (DateOnly?)null : null;

                Console.Write($"Ange slutdatum som du är ansvarig över {cabinChoice.Name} (Tryck 'ENTER' för att ej ange ett datum: ");
                Console.Write("Ange utcheckningsdatum (yyyy-mm-dd) Tryck 'ENTER' för att ej ange ett datum: ");
                string inputCheckOut = Console.ReadLine();
                DateOnly? checkOut = !string.IsNullOrWhiteSpace(inputCheckOut) ?
                    DateOnly.TryParseExact(inputCheckOut, "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out var parsedCheckOut) ?
                    parsedCheckOut : (DateOnly?)null : null;

                Console.Write("Arbetstitel: ");
                var title = Console.ReadLine();
                

                    Console.Write("Födelsedatum (yyyy-mm-dd): ");
                if (DateOnly.TryParseExact(Console.ReadLine(), "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
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
                        Check_In = checkIn,
                        Check_Out = checkOut
                    };

                    Console.Clear();
                    Console.WriteLine($"Counselor {firstName} {lastName} har blivit tillagd.");

                    context.Counselors.Add(newCounselor);
                    context.SaveChanges();
                }// Lägg till i databasen
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ogiltigt datumformat. Counselor {firstName} {lastName} kunde inte läggas till.");

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
                Console.Write("Födelsedatum (yyyy-mm-dd): ");
                if (DateOnly.TryParseExact(Console.ReadLine(), "yyyy-mm-dd", null, System.Globalization.DateTimeStyles.None, out DateOnly dateOfBirth))
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

                    Console.WriteLine("Ange ID för den camper du önskar bli kopplad till: ");
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
                            Console.WriteLine($"NextOfKin {firstName} {lastName} blivit tillagd, samt länkats till Camper med ID: {camperId}.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Camper ID kunde inte hittas. Angiven NextOfKin har inte blivit tillagd, vänligen försök igen.");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltigt datumformat. NextOfKin har inte blivit tillagd.");
                }
            }
        }

        public static void AddCabin()
        {
            Console.Write("Ange namn på cabin: ");
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
            Console.Write("Ange förnamn på camper du vill ta bort: ");
            var firstName = Console.ReadLine();

            Console.Write("Ange efternamn på camper du vill ta bort: ");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            var camperToRemove = context.Campers
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (camperToRemove != null)
            {
                context.Campers.Remove(camperToRemove);
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine($"Camper {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Camper {firstName} {lastName} hittades inte.");
            }
        }

        public static void DeleteCounselor()
        {
            Console.Write("Ange förnamn på den counsolor du vill ta bort: ");
            var firstName = Console.ReadLine();

            Console.Write("Ange efternamn på den counsolor du vill ta bort: ");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            var counselorToRemove = context.Counselors
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (counselorToRemove != null)
            {
                context.Counselors.Remove(counselorToRemove);
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine($"Counselor {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Counselor {firstName} {lastName} hittades inte.");
            }
        }

        public static void DeleteNextOfKin()
        {
            Console.Write("Ange förnamn på den Next of Kin du vill ta bort: ");
            var firstName = Console.ReadLine();

            Console.Write("Ange efternamn på den Next of Kin du vill ta bort: ");
            var lastName = Console.ReadLine();

            using var context = new CampContext();

            var nextOfKinToRemove = context.NextOfKins
                .FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);

            if (nextOfKinToRemove != null)
            {
                context.NextOfKins.Remove(nextOfKinToRemove);
                context.SaveChanges();
                Console.Clear();
                Console.WriteLine($"Next Of Kin {firstName} {lastName} har blivit borttagen.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Next Of Kin {firstName} {lastName} hittades inte.");
            }
        }

        public static void DeleteCabin()
        {
            Console.Write("Ange namn på den cabin du vill ta bort: ");
            var cabinName = Console.ReadLine();
            using var context = new CampContext();

            var cabinToRemove = context.Cabins
                .Include(c => c.Campers) // Inkludera campers för den specifika stugan
                .FirstOrDefault(c => c.Name == cabinName);

            if (cabinToRemove != null)
            {
                if (cabinToRemove.Campers.Any())
                {
                    Console.Clear();
                    Console.WriteLine($"Kan inte ta bort {cabinName} eftersom den innehåller campers.");
                }
                else
                {
                    Console.Clear();
                    context.Cabins.Remove(cabinToRemove);
                    context.SaveChanges();
                    Console.WriteLine($"Cabin {cabinName} har blivit borttagen.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Cabin {cabinName} hittades inte.");
            }
        }


        //Samtliga Edit-metoder
        public static void EditCamper()
        {

            using var context = new CampContext();
            {
                Console.Write("Ange ID för den camper du vill ändra: ");
                int id = int.Parse(Console.ReadLine());

                var camper = context.Campers
                    .FirstOrDefault(c => c.Id == id);

                if (camper != null)
                {
                    Console.WriteLine($"Du ändrar nu: {camper.FirstName} {camper.LastName}, " +
                        $"{camper.DateOfBirth}, {camper.Phone}, {camper.Email}, {camper.Address}." +
                        $"\nIn- och utcheckning: {camper.Check_In} - {camper.Check_Out}");
                    Console.WriteLine();

                    Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank och tryck på 'Enter'.");
                    Console.WriteLine();

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

                    Console.Write("Ange nytt födelsedatum (yyyy-mm-dd):");
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

                    Console.Write("Vill du byta cabin? Ja/Nej: ");
                    string changeCabinChoice = Console.ReadLine();
                    if (changeCabinChoice == "Ja" || changeCabinChoice == "ja")
                    {
                        Console.WriteLine("Välj en ny cabin");
                        var cabinChoice = JunctionContext.chooseCabin(context); // Anropar JunctionContext som presenterar listan med befintliga cabins att välja från 

                        camper.Cabin = cabinChoice;

                        Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} har bytt till cabin med namn {cabinChoice.Name}");
                    }

                    else if (changeCabinChoice == "Nej" || changeCabinChoice == "nej")
                    {
                        Console.WriteLine($"Camper {camper.FirstName} {camper.LastName} bor kvar i samma cabin som tidigare.");
                    }

                    Console.WriteLine();
                    Console.Write("Ange nytt datum för check-in (yyyy-MM-dd): ");
                    string newCheckIn = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCheckIn))
                    {
                        DateOnly parsedCheckIn;
                        if (DateOnly.TryParseExact(newCheckIn, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedCheckIn))
                        {
                            camper.Check_In = parsedCheckIn;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt datumformat. Startdatumet har inte ändrats.");
                        }
                    }

                    Console.Write("Ange nytt datum för check-out (yyyy-MM-dd): ");
                    string newCheckOut = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCheckOut))
                    {
                        DateOnly parsedCheckOut;
                        if (DateOnly.TryParseExact(newCheckOut, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedCheckOut))
                        {
                            camper.Check_Out = parsedCheckOut;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt datumformat. Slutdatumet har inte ändrats.");
                        }
                    }

                    context.SaveChanges();
                    Console.Clear();

                    Console.WriteLine("Informationen är uppdaterad!");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på enter för att återgå till menyn...");

                    Console.ReadLine();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Det finns ingen camper med det ID du angivit.");
                }
            }
        }

        public static void EditNextOfKin()
        {
            Console.Write("Ange ID för den Next Of Kin som du vill ändra: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var nextOfKin = context.NextOfKins
                .FirstOrDefault(c => c.Id == id);

            if (nextOfKin != null)
            {
                Console.WriteLine($"Du ändrar nu: {nextOfKin.FirstName} {nextOfKin.LastName}, " +
                    $"{nextOfKin.DateOfBirth}, {nextOfKin.Phone}, {nextOfKin.Email}, {nextOfKin.Address}.");
                Console.WriteLine();

                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");
                Console.WriteLine();

                Console.Write("Ange nytt förnamn:");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    nextOfKin.FirstName = newFirstName;
                }

                Console.Write("Ange nytt efternamn:");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    nextOfKin.LastName = newLastName;
                }

                Console.Write("Ange nytt födelsedatum (yyyy-mm-dd):");
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

                Console.Write("Ange nytt telefonnummer:");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    nextOfKin.Phone = newPhone;
                }

                Console.Write("Ange ny emailadress:");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    nextOfKin.Email = newEmail;
                }

                Console.Write("Ange ny adress:");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAddress))
                {
                    nextOfKin.Address = newAddress;
                }

                context.SaveChanges();
                Console.Clear();

                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine();
                Console.WriteLine("Tryck på enter för att återgå till menyn...");

                Console.ReadLine();
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Det finns ingen Next of kin med det ID du angivit.");
            }
        }


        public static void EditCounselor()
        {
            Console.Write("Ange ID för den counselor du vill ändra: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var counselor = context.Counselors
                .FirstOrDefault(c => c.Id == id);

            if (counselor != null)
            {
                Console.WriteLine($"Du ändrar nu: {counselor.Title}, {counselor.FirstName} {counselor.LastName}, " +
                    $"{counselor.DateOfBirth}, {counselor.Phone}, {counselor.Email}, {counselor.Address}." +
                    $"\nStugansvarig: {counselor.Check_In} - {counselor.Check_Out}"
                    );
                Console.WriteLine();

                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");
                Console.WriteLine();


                Console.Write("Ange ny titel: ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    counselor.Title = newTitle;
                }

                Console.Write("Ange nytt förnamn: ");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    counselor.FirstName = newFirstName;
                }

                Console.Write("Ange nytt efternamn: ");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    counselor.LastName = newLastName;
                }

                Console.Write("Ange nytt födelsedatum (yyyy-mm-dd): ");
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

                Console.Write("Ange nytt telefonnummer: ");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPhone))
                {
                    counselor.Phone = newPhone;
                }

                Console.Write("Ange ny emailadress: ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    counselor.Email = newEmail;
                }

                Console.Write("Ange ny adress: ");
                string newAddress = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAddress))
                {
                    counselor.Address = newAddress;
                }

                Console.Write("Vill du byta cabin? Ja/Nej: ");
                string changeCabinChoice = Console.ReadLine();
                if (changeCabinChoice == "Ja" || changeCabinChoice == "ja")
                {
                    Console.WriteLine("Välj en ny cabin");
                    var cabinChoice = JunctionContext.chooseCabin(context); // Anropar JunctionContext som presenterar listan med befintliga cabins att välja från 

                    counselor.Cabin = cabinChoice;

                    Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} har blivit tilldelad cabin med namn {cabinChoice.Name}.");

                }

                else if (changeCabinChoice == "Nej" || changeCabinChoice == "nej")
                {
                    Console.WriteLine($"Counselor {counselor.FirstName} {counselor.LastName} ansvarar för samma cabin som tidigare.");
                }

                Console.WriteLine();
                Console.Write("Ange nytt startdatum för cabin-ansvar (yyyy-MM-dd): ");
                string newCheckIn = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newCheckIn))
                {
                    DateOnly parsedCheckIn;
                    if (DateOnly.TryParseExact(newCheckIn, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedCheckIn))
                    {
                        counselor.Check_In = parsedCheckIn;
                        Console.WriteLine($"Startdatum ändrat till: {parsedCheckIn.ToString("yyyy-MM-dd")}");
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt datumformat. Startdatumet har inte ändrats.");
                    }
                }

                Console.Write("Ange nytt slutdatum för cabin-ansvar (yyyy-MM-dd): ");
                string newCheckOut = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newCheckOut))
                {
                    DateOnly parsedCheckOut;
                    if(DateOnly.TryParseExact(newCheckOut, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out parsedCheckOut))
                    {
                        counselor.Check_Out = parsedCheckOut;
                        Console.WriteLine($"Slutdatumet ändrat till: {parsedCheckOut.ToString("yyyy-MM-dd")}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt datumformat. Slutdatumet har inte ändrats.");
                    }
                }

                context.SaveChanges();

                Console.Clear();

                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine();
                Console.WriteLine("Tryck på enter för att återgå till menyn...");

                Console.ReadLine();
                Console.Clear();

            }
            else
            {
                Console.WriteLine("Det finns ingen counselor med det namn du angivit.");
            }
        }

        public static void EditCabin()
        {
            Console.Write("Ange ID för den cabin du vill ändra: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new CampContext();

            var cabin = context.Cabins
                .FirstOrDefault(c => c.Id == id);

            if (cabin != null)
            {
                Console.WriteLine($"Du ändrar nu cabin med namn {cabin.Name} samt cabinID {cabin.Id}."
                    );

                Console.WriteLine();
                Console.WriteLine("Fyll i ny information. För att behålla befintlig information, lämna rutan blank");
                Console.WriteLine();

                Console.Write("Ange nytt namn på cabin: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    cabin.Name = newName;
                }

                context.SaveChanges();
                Console.Clear();

                Console.WriteLine("Informationen är uppdaterad!");
                Console.WriteLine();
                Console.WriteLine("Tryck på enter för att återgå till menyn...");

                Console.ReadLine();
                Console.Clear();

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
                context.Populate();
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
                        Console.WriteLine("Ange namn på cabin för att visa campers:");
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
                            Console.WriteLine("Inga campers finns i den cabin du angivit.");
                        }
                    }

                    else if (option == 1) //Visa campers baserat på counselor
                    {
                        Console.WriteLine("Ange förnamn på önskad counselor för att visa campers:");
                        string counselorFirstName = Console.ReadLine();

                        Console.WriteLine("Ange efternamn på önskad counselor för att visa campers:");
                        string counselorLastName = Console.ReadLine();

                        Counselor? counselor = context.Counselors.Where(c => c.FirstName == counselorFirstName && c.LastName == counselorLastName).FirstOrDefault();

                        if (counselor == null)
                        {
                            Console.WriteLine("Det finns ingen counselor med angivet namn.");
                            return;
                        }

                        var counselorsCabin = counselor.CabinName;
                        if (counselorsCabin == null)
                        {
                            Console.WriteLine($"Counselor med namn {counselorFirstName} {counselorLastName} är för tillfället inte tilldelad någon cabin");
                            return;
                        }

                        var campersWithCounselor = context.Campers.Where(c => c.CabinName == counselorsCabin).ToList();
                        if (!campersWithCounselor.Any())
                        {
                            Console.WriteLine("Angiven counselor är tilldelad en cabin men den innehåller inte några campers.");
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
                            Console.WriteLine("Varning! Följande cabins saknar en counselor:");
                            foreach (var cabin in cabinsWithoutCounselor)
                            {
                                Console.WriteLine($"Cabin ID: {cabin.Id} - Namn: {cabin.Name}");
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
