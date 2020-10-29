using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DnsClient.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User.API.Entities;
using User.API.Repository;

namespace User.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserController> logger;
        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserEntity>),(int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsersAsync()
        {
            var users = await userRepository.GetUsersAsync();
            return Ok(users);

        }


        [HttpGet("{id}",Name = "GetUser")]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserEntity>> GetUserAsync(string id)
        {
            var user = await userRepository.GetUserAsync(id);
            if (user == null)
            {
                logger.LogError($"User with id: {id} Not Found");
                return NotFound();
            }
            return Ok(user);

        }

        [HttpPost]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserEntity>> CreateUserAsync([FromBody] UserEntity user)
        {
           await userRepository.CreateUserAsync(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);

        }

        [HttpPut]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserEntity user)
        {
            var result = await userRepository.UpdateUserAsync(user);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(UserEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteUserAsync(string id)
        {
            var result = await userRepository.DeleteUserAsync(id);
            return Ok(result);

        }
    }
}
