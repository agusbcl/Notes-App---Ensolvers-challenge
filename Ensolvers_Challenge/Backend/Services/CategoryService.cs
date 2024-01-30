using Ensolvers_Challenge.Backend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using Ensolvers_Challenge.Shared.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Ensolvers_Challenge.Backend.Repositories.Interfaces;

namespace Ensolvers_Challenge.Backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<NoteService> _logger;

        public CategoryService(IMapper mapper, ILogger<NoteService> logger, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategories()
        {
            var serviceResponse = new ServiceResponse<List<CategoryDto>>();

            try
            {
                serviceResponse.Data = await _categoryRepository.GetAll()
                    .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error getting categories - {ex.Message}");
            }
            return serviceResponse;
        }
    }

}
