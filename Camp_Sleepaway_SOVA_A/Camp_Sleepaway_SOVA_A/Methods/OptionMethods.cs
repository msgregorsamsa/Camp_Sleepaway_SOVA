using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class OptionMethods
    {
        public static void AddingOptions()
        {
            bool running = true;
            while (running)
            {
                int option = Program.ShowMenu("Vad vill du lägga till?", new[]
                {
                    "Camper",
                    "Counselor",
                    "Next Of Kin",
                    "Cabin",
                    "Avsluta"
                });

                Console.Clear();

                if (option == 0)
                {
                    
                    CRUDMethods.AddCamper();
                }

                else if (option == 1)
                {
                    //Metod för counselor
                }
                else if (option == 2)
                {
                    //Metod för Next Of Kin
                }
                else if (option == 3)
                {
                    //Metod för cabin
                }
                else
                {
                    running = false;
                    Console.WriteLine("Hejdå");
                }
            }
        }

        public static void DeleteOptions()
        {
            bool running = true;
            while (running)
            {
                int option = Program.ShowMenu("Vad vill du ta bort?", new[]
                {
                    "Camper",
                    "Counselor",
                    "Next Of Kin",
                    "Cabin",
                    "Avsluta"
                });

                if (option == 0)
                {
                    CRUDMethods.DeleteCamper();
                }
                else if (option == 1)
                {
                    //Metod för counselor
                }
                else if (option == 2)
                {
                    //Metod för Next Of Kin
                }
                else if (option == 3)
                {
                    //Metod för cabin
                }
                else
                {
                    running = false;
                    Console.WriteLine("Hejdå");
                }
            }
        }

        public static void EditOptions()
        {
            bool running = true;
            while (running)
            {
                int option = Program.ShowMenu("Vad vill du ändra?", new[]
                {
                    "Camper",
                    "Counselor",
                    "Next Of Kin",
                    "Cabin",
                    "Avsluta"
                });

                if (option == 0)
                {
                    //Metod för camper
                }
                else if (option == 1)
                {
                    //Metod för counselor
                }
                else if (option == 2)
                {
                    //Metod för Next Of Kin
                }
                else if (option == 3)
                {
                    //Metod för cabin
                }
                else
                {
                    running = false;
                    Console.WriteLine("Hejdå");
                }
            }
        }

        public static void ShowReportsOptions()
        {
            bool running = true;
            while (running)
            {
                int option = Program.ShowMenu("Vilken rapport vill du få ut?", new[]
                {
                    "Camper baserat på stuga eller counselor",
                    "Varningar för stugor utan counselors",
                    "Avsluta"
                });

                if (option == 0)
                {
                    //Metod för camper
                }
                else if (option == 1)
                {
                    //Metod för counselor
                }
                else
                {
                    running = false;
                    Console.WriteLine("Hejdå");
                }
            }
        }
    }
}
