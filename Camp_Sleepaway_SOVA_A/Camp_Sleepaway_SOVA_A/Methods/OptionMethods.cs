using Microsoft.EntityFrameworkCore;
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
                    "Återgå till huvudmeny"
                });

                Console.Clear();

                if (option == 0)
                {
                    CRUDMethods.AddCamper();
                }
                else if (option == 1)
                {
                    CRUDMethods.AddCounselor();
                }
                else if (option == 2)
                {
                    CRUDMethods.AddNextOfKin();
                }
                else if (option == 3)
                {
                    CRUDMethods.AddCabin();
                }
                else
                {
                    running = false;
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
                    CRUDMethods.DeleteCounselor();
                }
                else if (option == 2)
                {
                    CRUDMethods.DeleteNextOfKin();
                }
                else if (option == 3)
                {
                    CRUDMethods.DeleteCabin();
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
                    CRUDMethods.EditCamper();
                }
                else if (option == 1)
                {
                    CRUDMethods.EditCounselor();
                }
                else if (option == 2)
                {
                    CRUDMethods.EditNextOfKin();
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
                    "Visa alla campers",
                    "Varningar för stugor utan counselors",
                    "Avsluta"
                });

                if (option == 0)
                {
                    CRUDMethods.ShowReportsForCampers();
                }
                else if (option == 1)
                {
                    CRUDMethods.ReportsForMissingCouncelor();
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
