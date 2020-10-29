using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Entities;

namespace User.API.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync();
        Task<UserEntity> GetUserAsync(string id);
        Task CreateUserAsync(UserEntity user);
        Task<bool> UpdateUserAsync(UserEntity user);
        Task<bool> DeleteUserAsync(string id);
    }
}
