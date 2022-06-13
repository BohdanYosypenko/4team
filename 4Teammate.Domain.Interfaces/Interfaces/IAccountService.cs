using _4Teammate.Domain.Models.Account;

namespace _4Teammate.Domain.Services.Interfaces;

public interface IAccountService
{
  public Task<TokenModel> LoginAsync(LoginModel loginModel);
  public Task<bool> LogoutAsync(string username);
  public Task<TokenModel> RegisterAsync(RegisterModel registerModel);
  public Task<TokenModel> RefreshTokenAsync(TokenModel tokenModel);

}
