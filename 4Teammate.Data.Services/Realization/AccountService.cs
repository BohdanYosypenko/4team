using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;
using _4Teammate.Domain.Models.Account;
using _4Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace _4Teammate.Data.Services.Realization
{
  public class AccountService : IAccountService
  {
    private readonly UserManager<AccountUser> _userManager;    
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(UserManager<AccountUser> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
    {
      _userManager = userManager;
      _configuration = configuration;
      _unitOfWork = unitOfWork;
    }

    public async Task<TokenModel> LoginAsync(LoginModel loginModel)
    {
      var user = await _userManager.FindByNameAsync(loginModel.Username);
      if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
      {

        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim> {
          new Claim(ClaimTypes.Name, user.UserName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in userRoles)
        {
          authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = CreateToken(authClaims);
        var refreshToken = GenerateRefreshToken();


        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        await _userManager.UpdateAsync(user);

        return new TokenModel()
        {
          AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
          RefreshToken = refreshToken,
        };

      }
      return null;
    }

    public async Task<bool> LogoutAsync(string username)
    {
      var user = await _userManager.FindByNameAsync(username);
      user.RefreshToken = null;
      return (await _userManager.UpdateAsync(user)).Succeeded;
    }

    public async Task<TokenModel> RefreshTokenAsync(TokenModel tokenModel)
    {
      if (tokenModel == null)
      {
        return null;
      }

      var principal = GetPrincipalFromExpiredToken(tokenModel.AccessToken);
      if (principal == null)
      {
        return null;
      }

      string name = principal.Identity.Name;

      var user = await _userManager.FindByNameAsync(name);
      if (user == null || tokenModel.RefreshToken != user.RefreshToken || DateTime.Now > user.RefreshTokenExpiryTime)
      {
        return null;
      }

      var newAccessToken = CreateToken(principal.Claims.ToList());
      var newRefreshToken = GenerateRefreshToken();

      user.RefreshToken = newRefreshToken;
      await _userManager.UpdateAsync(user);

      return new TokenModel()
      {
        AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        RefreshToken = newRefreshToken
      };
    }

    public async Task<TokenModel> RegisterAsync(RegisterModel registerModel)
    {
      var userExist = await _userManager.FindByNameAsync(registerModel.Username);
      if (userExist != null)
        return null;

      var user = new AccountUser()
      {
        Email = registerModel.Email,
        SecurityStamp = Guid.NewGuid().ToString(),
        UserName = registerModel.Username
      };

      var result = await _userManager.CreateAsync(user, registerModel.Password);
      if (!result.Succeeded)
        return null;


      var registeredUser = await _userManager.FindByNameAsync(user.UserName);

      if (registeredUser != null && await _userManager.CheckPasswordAsync(registeredUser, registerModel.Password))
      {
        await _unitOfWork.TeammateUser.CreateAsync(new TeammateUserEntity
        {
          AccountFID = user.Id,
        });
        _unitOfWork.SaveAsync();
      }

      var userRoles = await _userManager.GetRolesAsync(registeredUser);

      var authClaims = new List<Claim> {
          new Claim(ClaimTypes.Name, registeredUser.UserName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

      foreach (var role in userRoles)
      {
        authClaims.Add(new Claim(ClaimTypes.Role, role));
      }

      var token = CreateToken(authClaims);
      var refreshToken = GenerateRefreshToken();


      _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

      registeredUser.RefreshToken = refreshToken;
      registeredUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

      await _userManager.UpdateAsync(registeredUser);

      return new TokenModel()
      {
        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
        RefreshToken = refreshToken,
      };
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
        ValidateLifetime = false
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var principle = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
      if (securityToken is not JwtSecurityToken)
      {
        throw new SecurityTokenException("InvalidToken");
      }

      return principle;
    }

    private static string GenerateRefreshToken()
    {
      var randomNumber = new byte[64];
      using var rng = RandomNumberGenerator.Create();
      rng.GetBytes(randomNumber);
      return Convert.ToBase64String(randomNumber);
    }

    private JwtSecurityToken CreateToken(List<Claim> authClaims)
    {
      var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
      _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

      var token = new JwtSecurityToken(
          issuer: _configuration["JWT:ValidIssuer"],
          audience: _configuration["JWT:ValidAudience"],
          expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
          claims: authClaims,
          signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
          );

      return token;
    }
  }
}
