using EmployeeManagement.Data;
using EmployeeManagement.Dto;
using EmployeeManagement.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ViewEmployeeDto> AddEmployeeAsync(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee
            {
                UserId = addEmployeeDto.UserId,
                Title = addEmployeeDto.Title,
                CategoryId = addEmployeeDto.CategoryId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var createdEmployee = await _context.Employees
                .Include(e => e.User)
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            return createdEmployee.Adapt<ViewEmployeeDto>();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                throw new KeyNotFoundException($"Employee {id} not found");
            }

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ViewEmployeeDto>> GetAllAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.User)
                .Include(e => e.Category)
                .ToListAsync();

            return employees.Adapt<IEnumerable<ViewEmployeeDto>>();
        }

        public async Task<ViewEmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.User)
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);

            return employee?.Adapt<ViewEmployeeDto>();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByCategoryIdAsync(int categoryId)
        {
            return await _context.Employees
                .Include(e => e.Category)
                .Include(e => e.User)
                .Where(e => e.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeDto employeeDto)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            emp.Title = employeeDto.Title;
            emp.CategoryId = employeeDto.CategoryId;

            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
        }
    }
}
