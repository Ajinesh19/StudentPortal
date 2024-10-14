using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

namespace StudentPortal.Repositry
{
    public class BookRepositry
    {
        private readonly BookStoreContext _context;

        public BookRepositry(BookStoreContext context)
        {
            _context = context;
        }


        public async Task<int> AddNewBook(BookModel model)
        {
            
                var newbook = new Book()
                {
                    Author = model.Author,
                    Title = model.Title,
                    Description = model.Description ?? "No description available",
                    LanguageId = model.LanguageId,
                    CoverImageUrl = model.CoverImageUrl,
                   
                };

                await _context.Books.AddAsync(newbook);
                await _context.SaveChangesAsync();
                return newbook.Id;
            }
            

        public async Task<List<BookModel>> GetAllBooks()
        {
            var allbookss = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    allbookss.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description ?? "No description available",
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        CoverImageUrl = book.CoverImageUrl,
                       
                        
                        
                        



                    });
                }
            }
            return allbookss;

        }
        public async Task<BookModel?> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {

                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    CoverImageUrl = book.CoverImageUrl,
                   

                };
                return bookDetails;
            }

            return null;

        }



        public List<BookModel>? SearchBook(string title, string authorName)
        {
            return null;

        }
        //private List<BookModel> DataSources()
        //{
        //    return new List<BookModel>()
        //    //{
        //    //    new BookModel(){Id=1,Title="Mvc",Author="Aji",Description="this is a book"},
        //    //    new BookModel(){Id=2,Title="C#",Author="Alf",Description="this is a book"},
        //    //    new BookModel(){Id=3,Title="Java",Author="Fer",Description="this is a book"},
        //    //    new BookModel(){Id=4,Title="Python",Author="Nit",Description="this is a book"},

        //    };
    }
}





