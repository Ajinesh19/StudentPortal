using Microsoft.EntityFrameworkCore;

using StudentPortal.Data;
using StudentPortal.Models;

namespace StudentPortal.Repositry
{
    public class LanguageRepositry
    {
        private readonly BookStoreContext _context;

        public LanguageRepositry(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<LangugageModel>> GetLanguages()
        {
            return await _context.Languages.Select(x => new LangugageModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
           
        }
    }
}
