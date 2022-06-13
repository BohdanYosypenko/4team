using System.Threading.Tasks;
using _4Teammate.Data.Entities;
using _4Teammate.Domain.Models.Account;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _4Teammate.API.Controllers;

[AllowAnonymous]
[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

  private readonly IAccountService _accountService;

  public AccountController(IAccountService accountService)
  {
    _accountService = accountService;
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginModel loginModel)
  {
    var result = await _accountService.LoginAsync(loginModel);
    return result is null ? BadRequest() : Ok(result);
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterModel registerModel)
  {
    var result = await _accountService.RegisterAsync(registerModel);
    return result is null ? BadRequest() : Ok(result);
  }

  [Authorize]
  [HttpPost("revoke/{username}")]
  public async Task<IActionResult> GetCurrentUser([FromHeader] string username)
  {
    await _accountService.LogoutAsync(username);
    return Ok();
  }

  [HttpPost("refresh-token")]  
  public async Task<IActionResult> RefreshToken([FromBody] TokenModel tokenModel)
  {
    var result = await _accountService.RefreshTokenAsync(tokenModel);
    return result is null ? BadRequest() : Ok(result);
  }
}
