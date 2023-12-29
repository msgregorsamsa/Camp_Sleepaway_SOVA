﻿
using System.ComponentModel.DataAnnotations;

namespace Camp_Sleepaway_SOVA
{
    public class Counselor : Person
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public bool OnCabinDuty { get; set; }


        public int? CabinId { get; set; }
        public string CabinName { get; set; }
        public virtual Cabin Cabin { get; set; }


        public List<Stay> Stays { get; set; } = new();

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateOnly Check_In { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateOnly Check_Out { get; set; }

    }
}

