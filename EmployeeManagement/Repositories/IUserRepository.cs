using EmployeeManagement.Dto;

namespace EmployeeManagement.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<ViewUserDto>> GetAllAsync();

        Task<ViewUserDto> GetUserByIdAsync(int id);

        Task UpdateUserAsync(int id, UpdateUserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
