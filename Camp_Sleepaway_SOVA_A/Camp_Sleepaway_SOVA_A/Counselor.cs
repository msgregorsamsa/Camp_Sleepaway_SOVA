
using System.ComponentModel.DataAnnotations;

namespace Camp_Sleepaway_SOVA
{
    public class Counselor : Person
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string? CabinName { get; set; }
        public virtual Cabin Cabin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateOnly? Check_In { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateOnly? Check_Out { get; set; }

    }
}

