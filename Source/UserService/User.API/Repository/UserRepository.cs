using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Data;
using User.API.Entities;

namespace User.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext userContext;
        public UserRepository(IUserContext context)
        {
            userContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            return await userContext.Users.Find(u => true).ToListAsync();

        }
        public async Task<UserEntity> GetUserAsync(string id)
        {
            return await userContext.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(UserEntity user)
        {
            await userContext.Users.InsertOneAsync(user);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var result = await userContext
                                    .Users
                                    .DeleteOneAsync(filter: u => u.Id == id);
            return (result.IsAcknowledged && result.DeletedCount > 0);
        }

         public async Task<bool> UpdateUserAsync(UserEntity user)
        {
            var result = await userContext
                                    .Users
                                    .ReplaceOneAsync(filter: u => u.Id == user.Id, replacement: user);
            return (result.IsAcknowledged && result.ModifiedCount > 0);
        }
    }
}
