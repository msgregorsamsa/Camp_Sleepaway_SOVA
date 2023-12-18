
namespace Camp_Sleepaway_SOVA
{
    public class Person
    {
        //public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; } //Rimlighetskrav på ålder
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
}
