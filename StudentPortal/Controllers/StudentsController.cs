using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(AddStudentViewModel viewmodel)
        {
            var student = new Student
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                PhoneNumber = viewmodel.PhoneNumber,
                Subcribed = viewmodel.Subcribed,

            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
           var students= await dbContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {
         var student =await dbContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student = await dbContext.Students.FindAsync(viewmodel.Id);
            if (student is not null)
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.PhoneNumber = viewmodel.PhoneNumber;
                student.Subcribed = viewmodel.Subcribed;
                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", "Students");

        }
        [HttpPost]

        public async Task<IActionResult>Delete(Student viewmodel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>x.Id ==viewmodel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(viewmodel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
        }
    
    
}
