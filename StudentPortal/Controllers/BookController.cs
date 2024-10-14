using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

using StudentPortal.Models;
using StudentPortal.Models.Entities;
using StudentPortal.Repositry;

using System;

namespace StudentPortal.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepositry _bookRepositry;
        private readonly LanguageRepositry _languageRepositry;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public BookController(BookRepositry bookRepositry, LanguageRepositry languageRepositry, IWebHostEnvironment webHost)
        {
            _bookRepositry = bookRepositry;
            _languageRepositry = languageRepositry;
            _webHostEnvironment = webHost;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepositry.GetAllBooks();
            return View(data);
        }

        public async Task<IActionResult> GetBook(int id)
        {


            var book = await _bookRepositry.GetBookById(id);


            return View(book);  // Return the book model to the view
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 1)
        {
            var model = new BookModel(); // Added missing semicolon

            // Assuming `GetLanguages` method exists in `LanguageRepository`
            var languages = await _languageRepositry.GetLanguages();
            ViewBag.Languages = new SelectList(languages, "Id", "Name");
            // Correct method name and repository

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {

            Console.WriteLine("\n\n\n" + ModelState.IsValid);
            if (ModelState.IsValid)

            {

                if (bookModel.CoverPhoto != null)
                {
                    string folder = "book/Cover";
                    folder += Guid.NewGuid().ToString() + " " + bookModel.CoverPhoto.FileName;
                   bookModel.CoverImageUrl = folder ;
                    string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
                }
                int id = await _bookRepositry.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, BookId = id });
                    }
                }
                ViewBag.Languages = new SelectList(await _languageRepositry.GetLanguages(), ("Id", "Name"));

                ViewBag.IsSuccess = true;
                ViewBag.BookId = 0;
                return View(bookModel); // Pass the model back to the view
            }
        }
    }

   
    

//        private List<LangugageModel> GetLanguage()
//        {
//            return new List<LangugageModel>()
//            {
//                new LangugageModel() { Id = 1, text = "HINDI" },
//                new LangugageModel() { Id = 2, text = "Tamil" },
//                new LangugageModel() { Id = 3, text = "English" },
//            };
//        }
//    }
//}
