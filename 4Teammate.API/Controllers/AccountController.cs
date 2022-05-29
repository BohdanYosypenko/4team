using _4Teammate.API.DTO.AccountDTO;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Services.Realization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _4Teammate.API.Controllers;

[AllowAnonymous]
[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByNameAsync(loginDTO.Username);

        if (user == null)
        {
            return Unauthorized();
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

        if (result.Succeeded)
        {
            return Ok(CreateUserObject(user));
        }

        return Unauthorized("No password");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO registerDTO)
    {
        if (await _userManager.Users.AnyAsync(u => u.Email == registerDTO.Email))
        {
            return BadRequest("Email taken");
        }

        if (await _userManager.Users.AnyAsync(u => u.UserName == registerDTO.Username))
        {
            return BadRequest("Name taken");
        }

        var user = new User()
        {
            UserName = registerDTO.Username,
            Email = registerDTO.Email,
        };

        var result = await _userManager.CreateAsync(user, registerDTO.Password);

        if (result.Succeeded)
        {
            return Ok(CreateUserObject(user));
        }

        return BadRequest("Something goes wrong");
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
        return Ok(CreateUserObject(user));
    }

    private UserDTO CreateUserObject(User user)
    {
        return new UserDTO()
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }
}
