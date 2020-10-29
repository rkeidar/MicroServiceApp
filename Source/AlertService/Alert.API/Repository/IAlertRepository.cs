using Alerts.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.API.Repository
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alert>> GetAlertsAsync();
        Task<Alert> GetAlertAsync(string auid);

        Task<Alert> UpdateAlertAsync(Alert alert);

    }
}
