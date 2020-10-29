using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Alerts.API.Entities;
using Alerts.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Alerts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertRepository alertRepository;

        public AlertController(IAlertRepository alertRepository)
        {
            this.alertRepository = alertRepository ?? throw new ArgumentNullException(nameof(alertRepository));
        }

        [HttpGet("{auid}", Name = "GetAlert")]
        [ProducesResponseType(typeof(Alert), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Alert), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Alert>> GetAlertAsync(string auid)
        {
            var result = await alertRepository.GetAlertAsync(auid);
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Alert), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Alert>> UpdateAlertAsync([FromBody] Alert alert)
        {
            var result = await alertRepository.UpdateAlertAsync(alert);
            return Ok(result);
        }

        [HttpGet]
        [Route("alerts")]
        [ProducesResponseType(typeof(List<Alert>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Alert>>> GetAlertsAsync()
        {
            var alerts = await alertRepository.GetAlertsAsync();
            return Ok(alerts);
        }
    }
}
