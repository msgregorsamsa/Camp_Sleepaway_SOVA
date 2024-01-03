using System.ComponentModel.DataAnnotations;

namespace Camp_Sleepaway_SOVA
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(typeof(DateOnly), "2010-01-01", "1940-01-01")]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
}
