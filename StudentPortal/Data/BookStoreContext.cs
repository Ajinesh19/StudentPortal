using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using StudentPortal.Models.Entities;

namespace StudentPortal.Data
{
    public class BookStoreContext:IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext>options):base(options) 
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }

    }
}
