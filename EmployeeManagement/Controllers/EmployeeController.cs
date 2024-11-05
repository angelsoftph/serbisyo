using EmployeeManagement.Dto;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        private ICategoryRepository _categoryRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, ICategoryRepository categoryRepository)
        {
            _employeeRepository = employeeRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeDto addEmployeeDto)
        {
            if (addEmployeeDto == null)
            {
                return BadRequest("Invalid employee data.");
            }

            var employee = await _employeeRepository.AddEmployeeAsync(addEmployeeDto);
            return CreatedAtAction(nameof(CreateEmployee), new { id = employee.FirstName }, employee);
        }

        [HttpGet]
        public async Task<IEnumerable<ViewEmployeeDto>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewEmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IEnumerable<ViewEmployeeDto>> GetEmployeesByCategoryId(int categoryId)
        {
            return await _employeeRepository.GetEmployeesByCategoryIdAsync(categoryId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployeeById(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _employeeRepository.UpdateEmployeeAsync(id, employeeDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
