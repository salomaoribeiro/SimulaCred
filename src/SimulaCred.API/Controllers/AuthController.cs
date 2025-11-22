using Microsoft.AspNetCore.Mvc;
using SimulaCred.API.Interfaces.Services;
namespace SimulaCred.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        // admin admin porque não cadastrei no banco nada
        if (login.Username == "admin" && login.Password == "admin")
        {
            var token = _jwtService.GenerateToken(login.Username, new[] { "Admin" });
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

public class LoginModel
{
    public string Username { get; set; } = "admin";
    public string Password { get; set; } = "admin";
}
