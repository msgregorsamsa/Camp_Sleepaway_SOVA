
namespace Camp_Sleepaway_SOVA.Methods
{
    public class Filehandling
    {
        //Läser in grunddatan om Campers från csv-fil.
        static List<Camper> ReadCampers(string filePath)
        {
            var campers = new List<Camper>();

            using var reader = new StreamReader(filePath);

            var headerLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var values = line.Split(',');

                if (values.Length == 10)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var dateofbirth = DateOnly.ParseExact(values[2], "yyyy-mm-dd", null);
                    var phone = values[3];
                    var email = values[4];
                    var address = values[5];
                    int nextOfKin = int.Parse(values[6]);
                    var cabinName = values[7];
                    var checkIn = DateOnly.ParseExact(values[8], "yyyy-mm-dd", null);
                    var checkOut = DateOnly.ParseExact(values[9], "yyyy-mm-dd", null);
                    //var cabinID = int.Parse(values[10]);

                    var camper = new Camper
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateofbirth,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        NextOfKinId = nextOfKin,
                        CabinName = cabinName,
                        Check_In = checkIn,
                        Check_Out = checkOut,
                    };

                    campers.Add(camper);
                }
            }
            return campers;
        }

        //Läser in grunddatan om Next of Kins från csv-fil.
        static List<NextOfKin> ReadNOK(string filePath)
        {
            var nextOfKins = new List<NextOfKin>();
            var campers = new List<Camper>();

            using var reader = new StreamReader(filePath);

            var headerLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var values = line.Split(',');

                if (values.Length == 7)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var dateofbirth = DateOnly.ParseExact(values[2], "yyyy-mm-dd", null);
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

        //Läser in grunddatan om Counselors från csv-fil.
        static List<Counselor> ReadCounselor(string filePath)
        {
            var counselors = new List<Counselor>();

            using var reader = new StreamReader(filePath);

            var headerLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var values = line.Split(',');

                if (values.Length == 10)
                {
                    var firstName = values[0];
                    var lastName = values[1];
                    var dateofbirth = DateOnly.ParseExact(values[2], "yyyy-mm-dd", null);
                    var phone = values[3];
                    var email = values[4];
                    var address = values[5];
                    var title = values[6];
                    var cabinName = values[7];
                    //var cabinID = int.Parse(values[8]);
                    var checkIn = DateOnly.ParseExact(values[8], "yyyy-mm-dd", null);
                    var checkOut = DateOnly.ParseExact(values[9], "yyyy-mm-dd", null);

                    var counselor = new Counselor
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateofbirth,
                        Phone = phone,
                        Email = email,
                        Address = address,
                        Title = title,
                        CabinName = cabinName,
                        Check_In = checkIn,
                        Check_Out = checkOut
                    };
                    counselors.Add(counselor);
                }
            }
            return counselors;
        }

        //Läser in grunddatan om Cabins från csv-fil.
        static List<Cabin> ReadCabin(string filePath)
        {
            var cabins = new List<Cabin>();

            using var reader = new StreamReader(filePath);

            var headerLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                var values = line.Split(',');

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


        //Läser in datan med hjälp av metoderna ovan
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

                // Uppdatera NextOfKin-objekt med korrekta Camper-referenser baserat på CamperId
                foreach (var nextOfKin in nextOfKinFile)
                {
                    var camperId = nextOfKin.CamperId;

                    // Hitta matchande Camper
                    var matchingCamper = context.Campers.FirstOrDefault(c => c.Id == camperId);

                    if (matchingCamper != null)
                    {
                        // Lägg till nextOfKin i camperens lista över NextOfKins
                        matchingCamper.NextOfKins.Add(nextOfKin);
                    }
                }
                context.SaveChanges();
            }

        }
    }
}