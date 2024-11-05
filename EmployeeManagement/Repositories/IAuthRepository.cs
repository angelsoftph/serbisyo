using EmployeeManagement.Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password, string title, int categoryId);
        Task<User> Login(string email, string password);
        Task<bool> UserExists(string email);
        Task<User?> GetUserByIdAsync(int id);

    }
}