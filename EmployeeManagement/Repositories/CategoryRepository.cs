using EmployeeManagement.Data;
using EmployeeManagement.Dto;
using EmployeeManagement.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ViewCategoryDto> AddCategoryAsync(CategoryDto addCategoryDto)
        {
            var category = new Category
            {
                Name = addCategoryDto.Name,
                ParentId = addCategoryDto.ParentId
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var createdCategory = await _context.Categories.FindAsync(category.Id);

            return createdCategory.Adapt<ViewCategoryDto>();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var cat = await _context.Categories.FindAsync(id);

            if (cat == null)
            {
                throw new KeyNotFoundException($"Category {id} not found");
            }

            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto updateCategoryDto)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            cat.Name = updateCategoryDto.Name;
            cat.ParentId = updateCategoryDto.ParentId;

            _context.Categories.Update(cat);
            await _context.SaveChangesAsync();
        }
    }
}
