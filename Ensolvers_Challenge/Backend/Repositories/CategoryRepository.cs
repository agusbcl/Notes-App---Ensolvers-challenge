using Ensolvers_Challenge.Backend.Data;
using Ensolvers_Challenge.Backend.Models;
using Ensolvers_Challenge.Backend.Repositories.Interfaces;

namespace Ensolvers_Challenge.Backend.Repositories
{
    public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
