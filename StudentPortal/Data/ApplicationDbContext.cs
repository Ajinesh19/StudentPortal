using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

using StudentPortal.Models.Entities;

namespace StudentPortal.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
         
        }
        public DbSet<Student> Students { get; set; }
       
       
            
        }
    }

