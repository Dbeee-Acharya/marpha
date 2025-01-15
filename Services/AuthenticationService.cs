using marpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace marpha.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string users_file_path = Path.Combine(AppContext.BaseDirectory, "UserDetails.json");
        public bool IsAuthenticated { get; set; } = false;
        public string SelectedCurrency { get; set; } = "Npr.";

        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                var users = await GetAllUsersAsync();
                if(users.Any(u => u.UserName == user.UserName ))
                {
                    return false; // User exists already
                }

                users.Add(user);
                await SaveUserAsync(users);
                return true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"REGISTER ERROR: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LoginUserAsync(string userEmail, string password)
        {
            try
            {
                var users = await GetAllUsersAsync();
                var user = users.FirstOrDefault(u => u.UserEmail == userEmail && u.UserPassword == password);

                if(user != null)
                {
                    IsAuthenticated = true;
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"LOGIN ERROR: {ex.Message}");
                return false;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = new List<User>();

            if(!File.Exists(users_file_path))
            {
                return users;
            }

            var json = await File.ReadAllTextAsync(users_file_path);
            return string.IsNullOrEmpty(json) ? users : JsonSerializer.Deserialize<List<User>>(json) ?? users;
        }

        public async Task SaveUserAsync(List<User> users)
        {
            var json = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(users_file_path, json);
        }
        public async Task<int> GetNextUserIdAsync()
        {
            var users = await GetAllUsersAsync();
            return users.Any() ? users.Max(u => u.UserId) + 1 : 1;
        }

        public bool Logout()
        {
            IsAuthenticated = false;
            return true;
        }
    }
}
