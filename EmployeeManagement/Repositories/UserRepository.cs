using EmployeeManagement.Data;
using EmployeeManagement.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting User with ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<ViewUserDto>> GetAllAsync()
        {
            var users = await _context.Users.Where(u => u.Role == "W").ToListAsync();

            return users.Adapt<IEnumerable<ViewUserDto>>();
        }

        public async Task<ViewUserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user?.Adapt<ViewUserDto>();
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;
            user.Role = userDto.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
