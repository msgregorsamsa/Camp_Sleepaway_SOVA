using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class Filehandling
    {
        static List<Camper> ReadCampers(string filePath)
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
                if (values.Length == 10)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var dateofbirth = DateOnly.ParseExact(values[2], "M/d/yyyy", null);
                    var phone = values[3];
                    var email = values[4];
                    var address = values[5];
                    int nextOfKin = int.Parse(values[6]);
                    var cabinName = values[7];
                    var checkIn = DateOnly.ParseExact(values[8], "M/d/yyyy", null);
                    var checkOut = DateOnly.ParseExact(values[9], "M/d/yyyy", null);

                    var camper = new Camper
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateofbirth,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        NextOfKinId = nextOfKin,
                        CabinName  = cabinName,
                        Check_In = checkIn,
                        Check_Out = checkOut
                    };

                    campers.Add(camper);
                }
            }
            return campers;
        }

        static List<NextOfKin> ReadNOK(string filePath)
        {
            var nextOfKins = new List<NextOfKin>();
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
                if (values.Length == 7)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var dateofbirth = DateOnly.ParseExact(values[2], "M/d/yyyy", null);
                    var phone = values[3];
                    var email = values[4];
                    var address = values[5];
                    int campersId = int.Parse(values[6]);

                    var nextOfKin = new NextOfKin
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateofbirth,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        CamperId = campersId

                    };
                    nextOfKins.Add(nextOfKin);
                }

            }
            return nextOfKins;
        }

        static List<Counselor> ReadCounselor(string filePath)
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
                if (values.Length == 9)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var dateofbirth = DateOnly.ParseExact(values[2], "M/d/yyyy", null);
                    var phone = values[3];
                    var email = values[4];
                    var address = values[5];
                    var title = values[6];
                    var onCabinDuty = values[7];
                    var cabinName = values[8];

                    var counselor = new Counselor
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateofbirth,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        Title = title,
                        OnCabinDuty = bool.Parse(onCabinDuty),
                        CabinName = cabinName
                    };
                    counselors.Add(counselor);
                }
            }
            return counselors;
        }

        static List<Cabin> ReadCabin(string filePath)
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

        public static void ReadAllCSVFiles()
        {
            var camperFile = ReadCampers("CamperData.csv");
            var nextOfKinFile = ReadNOK("NextOfKinData.csv");
            var counselorFile = ReadCounselor("CounselorData.csv");
            var cabinFile = ReadCabin("CabinData.csv");

            using (var context = new CampContext())
            {
                foreach (var camper in camperFile)
                {
                    context.Campers.Add(camper);
                }

                foreach (var nextofKin in nextOfKinFile)
                {
                    context.NextOfKins.Add(nextofKin);
                }

                foreach (var counselor in counselorFile)
                {
                    context.Counselors.Add(counselor);
                }

                foreach (var cabin in cabinFile)
                {
                    context.Cabins.Add(cabin);
                }

                context.SaveChanges();
            }
        }
    }
}