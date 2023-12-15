﻿
namespace Camp_Sleepaway_SOVA
{
    public class Cabin 
    {
        public int Id { get; set; }
        public string Name { get; set; } //Stugnamn

        public int BedNumber { get; set; }

        public  DateTime Check_In { get; set; } 

        public DateTime Check_Out { get; set; }

        public ICollection<Camper> Campers { get; set; }

        public int? CounselorId { get; set; } // FK till ledare, kan vara null om ingen ledare är kopplad till stugan
        public virtual Counselor Counselor { get; set; } // Navigation property till Leader



        // Skapa koppling /public camper reference) till Camper - public  int Occupants { get; set; }

    }
}
