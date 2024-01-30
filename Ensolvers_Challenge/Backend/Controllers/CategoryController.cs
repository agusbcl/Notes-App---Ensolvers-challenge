using Ensolvers_Challenge.Backend.Services.Interfaces;
using Ensolvers_Challenge.Shared.Dtos.CategoryDtos;
using Ensolvers_Challenge.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ensolvers_Challenge.Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<ActionResult<ServiceResponse<List<CategoryDto>>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
    }
}
