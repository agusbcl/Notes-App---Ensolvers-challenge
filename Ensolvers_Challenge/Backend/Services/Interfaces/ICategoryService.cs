using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using Ensolvers_Challenge.Shared.Dtos;

namespace Ensolvers_Challenge.Backend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryDto>>> GetAllCategories();
    }
}
