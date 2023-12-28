
using System.ComponentModel.DataAnnotations;

namespace Camp_Sleepaway_SOVA
{
    public class Person
    {
        //public int Id { get; set; }
        [Required]
        public  string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(typeof(DateOnly), "1/1/2010", "1/1/1940")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
}
