﻿using Camp_Sleepaway_SOVA;
using Camp_Sleepaway_SOVA.Methods;
using Microsoft.Identity.Client;
using System.Globalization;

public class Program
{
    public static void ReadData()
    {
        //Filehandling.CamperCSV("CamperData.csv");
        //Filehandling.NextOfKinCSV("NextOfKinData.csv");
        //Filehandling.CounselorCSV("CounselorData.csv");
        //Filehandling.CabinCSV("CabinData.csv");
        Filehandling.ReadAllCSVFiles();
        Console.Clear();
        Console.WriteLine("Inläsningen av datan är slutförd.");
        Console.WriteLine();
    }

    public static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        bool running = true;
        while (running)
        {
            int option = ShowMenu("Välkommen! Vad vill du göra?", new[]
            {
                    "Läs in data",
                    "Lägg till",
                    "Ta bort",
                    "Ändra",
                    "Visa rapporter",
                    "lekstuga",
                    "Avsluta"
            });

            Console.Clear();

            if (option == 0) //Läs in data
            {
                ReadData();
            }
            else if (option == 1) // Meny för att lägga till
            {
                OptionMethods.AddingOptions();

            }
            else if (option == 2) //Meny för att ta bort
            {
                OptionMethods.DeleteOptions();
            }
            else if (option == 3) //Meny för att ändra
            {
                OptionMethods.EditOptions();
            }
            else if (option == 4) //Meny för att visa rapporter
            {
                OptionMethods.ShowReportsOptions();
            }
            else if (option == 5) //lekstuga
            {
                using (var context = new CampContext())
                {
                    var NOK = context.NextOfKins.Where(n => n.Id == 5).FirstOrDefault();
                    var camper= context.Campers.Where(c => c.Id == 7).FirstOrDefault();
                    if (camper != null && NOK != null)
                    {
                        NOK.Campers.Add(camper);
                        context.SaveChanges();
                        Console.WriteLine("Nu är ni sammankopplade, FÖRALLTID :)");
                    } else
                    {
                        Console.WriteLine("Går inte att koppla, FEL");
                    }
                }
            }
            else
            {
                running = false;
                Console.WriteLine("Hejdå");
            }
        }
    }

    public static int ShowMenu(string prompt, IEnumerable<string> options)
    {
        if (options == null || options.Count() == 0)
        {
            throw new ArgumentException("Cannot show a menu for an empty list of options.");
        }

        Console.WriteLine(prompt);

        // Hide the cursor that will blink after calling ReadKey.
        Console.CursorVisible = false;

        // Calculate the width of the widest option so we can make them all the same width later.
        int width = options.MaxBy(option => option.Length).Length;

        int selected = 0;
        int top = Console.CursorTop;
        for (int i = 0; i < options.Count(); i++)
        {
            // Start by highlighting the first option.
            if (i == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }

            var option = options.ElementAt(i);
            // Pad every option to make them the same width, so the highlight is equally wide everywhere.
            Console.WriteLine("- " + option.PadRight(width));

            Console.ResetColor();
        }
        Console.CursorLeft = 0;
        Console.CursorTop = top - 1;

        ConsoleKey? key = null;
        while (key != ConsoleKey.Enter)
        {
            key = Console.ReadKey(intercept: true).Key;

            // First restore the previously selected option so it's not highlighted anymore.
            Console.CursorTop = top + selected;
            string oldOption = options.ElementAt(selected);
            Console.Write("- " + oldOption.PadRight(width));
            Console.CursorLeft = 0;
            Console.ResetColor();

            // Then find the new selected option.
            if (key == ConsoleKey.DownArrow)
            {
                selected = Math.Min(selected + 1, options.Count() - 1);
            }
            else if (key == ConsoleKey.UpArrow)
            {
                selected = Math.Max(selected - 1, 0);
            }

            // Finally highlight the new selected option.
            Console.CursorTop = top + selected;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            string newOption = options.ElementAt(selected);
            Console.Write("- " + newOption.PadRight(width));
            Console.CursorLeft = 0;
            // Place the cursor one step above the new selected option so that we can scroll and also see the option above.
            Console.CursorTop = top + selected - 1;
            Console.ResetColor();
        }

        // Afterwards, place the cursor below the menu so we can see whatever comes next.
        Console.CursorTop = top + options.Count();

        // Show the cursor again and return the selected option.
        Console.CursorVisible = true;
        return selected;
    }
}

