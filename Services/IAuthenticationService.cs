using marpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marpha.Services
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUserAsync(User user);
        Task<User?> LoginUserAsync(string userEmail, string password);
        Task<List<User>> GetAllUsersAsync();
        Task SaveUserAsync(List<User> users);
        Task<int> GetNextUserIdAsync();
    }
}
