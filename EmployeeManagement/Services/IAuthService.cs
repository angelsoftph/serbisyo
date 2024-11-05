using EmployeeManagement.Dto;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IAuthService
    {
        Task<User> Register(RegisterDto request);
        Task<string> Login(LoginDto request);
    }
}
