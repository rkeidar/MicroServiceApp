using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Entities;
using User.API.Settings;

namespace User.API.Data
{
    public class UserContext : IUserContext
    {
        public IMongoCollection<UserEntity> Users { get; set; }
        public UserContext(IUserDBSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDB = mongoClient.GetDatabase(settings.DatabaseName);
            Users = mongoDB.GetCollection<UserEntity>(settings.CollectionName);

            UserContextSeed.SeedData(Users);

        }

    }
}
