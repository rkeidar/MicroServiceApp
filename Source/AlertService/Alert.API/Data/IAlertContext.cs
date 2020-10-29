using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.API.Data
{
    public interface IAlertContext
    {
        IDatabase Redis { get; set; }
    }
}
