using EmployeeManagement.Dto;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly IAuthRepository _authRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAuthService _authService;

        //public AuthController(IAuthRepository authRepository, IEmployeeRepository employeeRepository, IAuthService authService)
        public AuthController(IAuthService authService)
        {
            //_authRepository = authRepository;
            //_employeeRepository = employeeRepository;
            _authService = authService;
        }

        [HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUserById(int id)
        //{
        //    var user = await _authRepository.GetUserByIdAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(User user, string password, string title, int categoryId)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return BadRequest();
        //    }

        //    await _authRepository.RegisterAsync(user, password, title, categoryId);

        //    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(string email, string password)
        //{
        //    var user = await _authRepository.Login(email, password);

        //    if (user == null)
        //    {
        //        return Unauthorized("Invalid email or password.");
        //    }

        //    return Ok(new { message = "Login successful" });
        //}

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            var user = await _authService.Register(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            var token = await _authService.Login(request);
            return Ok(token);
        }
    }
}