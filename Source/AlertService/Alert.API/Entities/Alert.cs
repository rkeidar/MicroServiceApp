using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alerts.API.Entities
{
    public class Alert
    {
        public string Auid { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Severity { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime PublishedOn { get; set; }     
    }
}
