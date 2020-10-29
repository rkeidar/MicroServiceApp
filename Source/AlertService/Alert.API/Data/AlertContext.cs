using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.API.Data
{
    public class AlertContext : IAlertContext
    {
        private readonly ConnectionMultiplexer redisConnection;

        public AlertContext(ConnectionMultiplexer redisConnection)
        {
            this.redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection)); ;
            Redis = redisConnection.GetDatabase();

            _ = AlertContextSeed.SeedDataAsync(Redis);
        }

        public IDatabase Redis { get; set; }
    }
}
