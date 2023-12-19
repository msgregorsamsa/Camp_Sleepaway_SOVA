using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class Filehandling
    {
        public static void CSVFile(string filepath)
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
    }
}

