﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Camp_Sleepaway_SOVA
{
    public class Camper : Person
    {
        public int Id { get; set; }
        public string CabinName { get; set; }   
        public Cabin Cabin { get; set; }

        [NotMapped]
        public int NextOfKinId { get; set; }

        public string ParticipantTitle { get; set; }

        public List<NextOfKin> NextOfKins { get; set; } = new();  

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public  DateOnly? Check_In { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateOnly? Check_Out { get; set; }

    }
}