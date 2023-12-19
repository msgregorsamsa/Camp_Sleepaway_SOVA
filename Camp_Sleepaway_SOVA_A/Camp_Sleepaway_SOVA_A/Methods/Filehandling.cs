using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class Filehandling
    {
        public static void CamperCSV(string filepath)
        {
            var camperFile = ReadCSV("CamperData.csv");

            Console.WriteLine($"{camperFile.Count} rader hittades i CSV-filen");

            using var context = new CampContext();

            foreach (var camper in camperFile)
            {
                context.Add(camper);
            }
            context.SaveChanges();

            static List<Camper> ReadCSV(string filePath)
            {
                var campers = new List<Camper>();

                using var reader = new StreamReader(filePath);

                // Read the header line
                var headerLine = reader.ReadLine();

                while (!reader.EndOfStream) //Loopen pågår sålänge vi INTE nått slutet av filen
                {
                    var line = reader.ReadLine(); //Läser nästa rad i csv-filen
                    if (line == null)
                    {
                        break; //Loopen avbryts
                    }

                    var values = line.Split(','); //Lägger till ett kommatecken mellan varje rad i filen

                    //line.Split returnerar en array av strängar:
                    if (values.Length == 6)
                    {
                        var firstName = values[0];
                        var lastName = values[1];
                        var dateofbirth = DateTime.ParseExact(values[2], "M/d/yyyy", null);
                        var phone = values[3];
                        var email = values[4];
                        var address = values[5];

                        var camper = new Camper
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            DateOfBirth = dateofbirth,
                            Phone = phone,
                            Email = email,
                            Address = address
                        };
                        campers.Add(camper);
                    }
                }
                return campers;
            }
        }

        public static void NextOfKinCSV(string filepath)
        {
            var nextOfKinFile = ReadCSV("NextOfKinData.csv");

            Console.WriteLine($"{nextOfKinFile.Count} rader hittades i CSV-filen");

            using var context = new CampContext();

            foreach (var nextofKin in nextOfKinFile)
            {
                context.Add(nextofKin);
            }
            context.SaveChanges();

            static List<NextOfKin> ReadCSV(string filePath)
            {
                var nextOfKins = new List<NextOfKin>();

                using var reader = new StreamReader(filePath);

                // Read the header line
                var headerLine = reader.ReadLine();

                while (!reader.EndOfStream) //Loopen pågår sålänge vi INTE nått slutet av filen
                {
                    var line = reader.ReadLine(); //Läser nästa rad i csv-filen
                    if (line == null)
                    {
                        break; //Loopen avbryts
                    }

                    var values = line.Split(','); //Lägger till ett kommatecken mellan varje rad i filen

                    //line.Split returnerar en array av strängar:
                    if (values.Length == 6)
                    {
                        var firstName = values[0];
                        var lastName = values[1];
                        var dateofbirth = DateTime.ParseExact(values[2], "M/d/yyyy", null);
                        var phone = values[3];
                        var email = values[4];
                        var address = values[5];

                        var nextOfKin = new NextOfKin
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            DateOfBirth = dateofbirth,
                            Phone = phone,
                            Email = email,
                            Address = address
                        };
                        nextOfKins.Add(nextOfKin);
                    }
                }
                return nextOfKins;
            }
        }

        public static void CounselorCSV(string filepath)
        {
            var counselorFile = ReadCSV("CounselorData.csv");

            Console.WriteLine($"{counselorFile.Count} rader hittades i CSV-filen");

            using var context = new CampContext();

            foreach (var counselor in counselorFile)
            {
                context.Add(counselor);
            }
            context.SaveChanges();

            static List<Counselor> ReadCSV(string filePath)
            {
                var counselors = new List<Counselor>();

                using var reader = new StreamReader(filePath);

                // Read the header line
                var headerLine = reader.ReadLine();

                while (!reader.EndOfStream) //Loopen pågår sålänge vi INTE nått slutet av filen
                {
                    var line = reader.ReadLine(); //Läser nästa rad i csv-filen
                    if (line == null)
                    {
                        break; //Loopen avbryts
                    }

                    var values = line.Split(','); //Lägger till ett kommatecken mellan varje rad i filen

                    //line.Split returnerar en array av strängar:
                    if (values.Length == 8)
                    {
                        var firstName = values[0];
                        var lastName = values[1];
                        var dateofbirth = DateTime.ParseExact(values[2], "M/d/yyyy", null);
                        var phone = values[3];
                        var email = values[4];
                        var address = values[5];
                        var title = values[6];
                        var onCabinDuty = values[7];

                        var counselor = new Counselor
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            DateOfBirth = dateofbirth,
                            Phone = phone,
                            Email = email,
                            Address = address,
                            Title = title,
                            OnCabinDuty = bool.Parse(onCabinDuty)
                        };
                        counselors.Add(counselor);
                    }
                }
                return counselors;
            }
        }

        public static void CabinCSV(string filepath)
        {
            var cabinFile = ReadCSV("CabinData.csv");

            Console.WriteLine($"{cabinFile.Count} rader hittades i CSV-filen");

            using var context = new CampContext();

            foreach (var cabin in cabinFile)
            {
                context.Add(cabin);
            }
            context.SaveChanges();

            static List<Cabin> ReadCSV(string filePath)
            {
                var cabins = new List<Cabin>();

                using var reader = new StreamReader(filePath);

                // Read the header line
                var headerLine = reader.ReadLine();

                while (!reader.EndOfStream) //Loopen pågår sålänge vi INTE nått slutet av filen
                {
                    var line = reader.ReadLine(); //Läser nästa rad i csv-filen
                    if (line == null)
                    {
                        break; //Loopen avbryts
                    }

                    var values = line.Split(','); //Lägger till ett kommatecken mellan varje rad i filen

                    //line.Split returnerar en array av strängar:
                    if (values.Length == 1)
                    {
                        var name = values[0];

                        var cabin = new Cabin
                        {
                            Name = name 
                        };
                        cabins.Add(cabin);
                    }
                }
                return cabins;
            }
        }
    }
}

