using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
       
        public  string? Title { get; set; }
        
        public required string? Author { get; set; }
        public string? Description { get; set; }
        
        public  int LanguageId {get; set; }
        public Language? Language { get; set; }

        public string? CoverImageUrl { get; set; }

    }
}
