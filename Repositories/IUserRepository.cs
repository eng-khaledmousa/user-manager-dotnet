using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Entities;

namespace UserManager.Repositories{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(Guid id);
        Task<bool> CheckUserExistAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}