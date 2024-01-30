using Ensolvers_Challenge.Frontend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos;
using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using System.Net.Http.Json;

namespace Ensolvers_Challenge.Frontend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        private readonly ILogger<CategoryService> _logger;
        private const string CategoryUrl = "api/category";

        public CategoryService(HttpClient http, ILogger<CategoryService> logger)
        {
            _http = http;
            _logger = logger;
        }
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = new List<CategoryDto>();
            try
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<CategoryDto>>>(CategoryUrl);
                if (result != null && result.Success && result.Data != null)
                {
                    categories = result.Data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return categories;
        }
    }
}
