

using Microsoft.CodeAnalysis.CSharp.Syntax;

using StudentPortal.Helper;

using System.ComponentModel.DataAnnotations;
using System.Transactions;
namespace StudentPortal.Models
{
    public class BookModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Choose the date and time")]
        public DateTime? MyField { get; set; }

        public int Id { get; set; }

        [StringLength(50), MinLength(2)]
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        public string? Description { get; set; }


        [Required]
        public int LanguageId { get; set; }

        [Display(Name = "Choose the cover photo of your book")]
        [Required(ErrorMessage = "Please upload a cover photo.")]
        public IFormFile? CoverPhoto { get; set; }
        public string? CoverImageUrl { get; set; }
        //public string CoverImageUrl { get; set; }  // This is set after the file upload 
    }
}







        









