using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;

namespace Ensolvers_Challenge.Frontend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
    }
}
