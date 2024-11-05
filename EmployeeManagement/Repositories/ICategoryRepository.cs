using EmployeeManagement.Dto;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);

        Task<ViewCategoryDto> AddCategoryAsync(CategoryDto addCategoryDto);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto);

        Task DeleteCategoryAsync(int id);
    }
}
