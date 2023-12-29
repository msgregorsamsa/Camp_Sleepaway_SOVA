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
                    "Återgå till huvudmeny"
                });

                Console.Clear();

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
                    "Återgå till huvudmeny"
                });

                Console.Clear();

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
                    "Rapport för campers - Tryck 'Enter' för fler valmöjligheter",
                    "Rapport för campers med NextOfKins",
                    "Återgå till huvudmeny"
                });

                Console.Clear();

                if (option == 0)
                {
                    CRUDMethods.ReportsForCampers();
                    Console.Clear();
                }
                else if (option == 1)
                {
                    CRUDMethods.ReportForCampersWithNOK();
                    Console.Clear();
                }
                else
                {
                    running = false;
                }
            }
        }
    }
}
