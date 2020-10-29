using MongoDB.Driver;
using User.API.Entities;


namespace User.API.Data
{
    public interface IUserContext
    {
        IMongoCollection<UserEntity> Users { get; set; }
    }
}
