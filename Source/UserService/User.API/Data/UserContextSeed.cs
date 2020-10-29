using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using User.API.Entities;

namespace User.API.Data
{
    internal class UserContextSeed
    {

        public static async void SeedData(IMongoCollection<UserEntity> users)
        {
            bool existsUsers = users.Find(u => true).Any();
            if (!existsUsers)
            {
                await users.InsertManyAsync(GetPreConfiguredUsers());
            }
        }

        private static IEnumerable<UserEntity> GetPreConfiguredUsers()
        {
            return new List<UserEntity>()
            {
                new UserEntity()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    EMail = "jsmith@email.com",
                    PhoneNumber = "123-456-7890"
                },
                new UserEntity()
                {
                    FirstName = "Amy",
                    LastName = "Jones",
                    EMail = "ajones@email.com",
                    PhoneNumber = "111-456-7890"
                }
            };
        }
    }
}