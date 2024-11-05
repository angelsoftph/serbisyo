using EmployeeManagement.Dto;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<ViewEmployeeDto>> GetAllAsync();
        Task<IEnumerable<Employee>> GetEmployeesByCategoryIdAsync(int categoryId);

        Task<ViewEmployeeDto> GetEmployeeByIdAsync(int id);

        Task<ViewEmployeeDto> AddEmployeeAsync(AddEmployeeDto addEmployeeDto);

        Task UpdateEmployeeAsync(int id, UpdateEmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
