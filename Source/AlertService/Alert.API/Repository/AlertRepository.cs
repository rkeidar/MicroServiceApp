using Alerts.API.Data;
using Alerts.API.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.API.Repository
{
    public class AlertRepository : IAlertRepository
    {
        private readonly IAlertContext alertContext;
        public AlertRepository(IAlertContext context)
        {
            alertContext = context;
        }

        public async Task<Alert> GetAlertAsync(string auid)
        {
            var alert = await alertContext.Redis.StringGetAsync(auid);

            if (alert.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<Alert>(alert);
        }

        public async Task<Alert> UpdateAlertAsync(Alert alert)
        {
            alert.PublishedOn = DateTime.UtcNow;
            var data = JsonConvert.SerializeObject(alert);
            var updated = await alertContext.Redis.StringSetAsync(alert.Auid, data);

            return await GetAlertAsync(alert.Auid);

        }

        public async Task<IEnumerable<Alert>> GetAlertsAsync()
        {
            List<string> alertsUid = new List<string>() { 
                "22d09502-0415-4c3f-983d-d998ffd28781" ,
                "22d09502-0415-4c3f-983d-d998ffd28781"
                };
            List<Alert> alerts = new List<Alert>();

            foreach(string alertuid in alertsUid)
            {
                var alert = await GetAlertAsync(alertuid);
                alerts.Add(alert);
            }

            return alerts;
        }
    }
}
