using EmployeeManagement.Dto;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto addCategoryDto)
        {
            if (addCategoryDto == null)
            {
                return BadRequest("Invalid category data.");
            }

            var category = await _categoryRepository.AddCategoryAsync(addCategoryDto);
            return CreatedAtAction(nameof(CreateCategory), new { id = category.Name }, category);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategoryById(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _categoryRepository.UpdateCategoryAsync(id, updateCategoryDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
