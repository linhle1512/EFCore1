namespace EFcore.Models
{
    public class Student : BaseEntity<int>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }
    }
}