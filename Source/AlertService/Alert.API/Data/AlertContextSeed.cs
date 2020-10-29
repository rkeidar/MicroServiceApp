using Alerts.API.Entities;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alerts.API.Data
{
    internal class AlertContextSeed
    {
        internal static async Task SeedDataAsync(IDatabase redis)
        {

            List<Alert> preConfiguredAlerts = new List<Alert>();
            preConfiguredAlerts.Add(new Alert
            {
                Auid = "22d09502-0415-4c3f-983d-d998ffd28781",
                Title = "Test Alert1",
                Body = "Test Alert Body",
                Severity = "High",
                Type = "Other",
                Status = "Standby",
                PublishedOn = DateTime.UtcNow
            });


            preConfiguredAlerts.Add(new Alert
            {
                Auid = "22d09502-0415-4c3f-983d-d998ffd28781",
                Title = "Test Alert2",
                Body = "Test2 Alert Body",
                Severity = "Medium",
                Type = "Other",
                Status = "Ended",
                PublishedOn = DateTime.UtcNow
            });


            preConfiguredAlerts.Add(new Alert
            {
                Auid = "5cd3bbff-30e2-47cf-bbcd-a50d28a95d96",
                Title = "Test Alert3",
                Body = "Test3 Alert Body",
                Severity = "Low",
                Type = "Other",
                Status = "Live",
                PublishedOn = DateTime.UtcNow
            });

            foreach (Alert alert in preConfiguredAlerts)
            {
                var alertStr = JsonConvert.SerializeObject(alert);
                await redis.StringSetAsync(alert.Auid, alertStr);
            }
        }
    }
}