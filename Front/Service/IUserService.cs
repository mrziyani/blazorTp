using Front.Models;

namespace Front.Service
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User model);
        Task<string> LoginUserAsync(LoginModel model);
        Task<IEnumerable<User>> GetAllUsersAsync(string token);
    }
}
