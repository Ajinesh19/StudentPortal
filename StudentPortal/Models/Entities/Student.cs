namespace StudentPortal.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
            public bool Subcribed { get; set; }
    }
}
