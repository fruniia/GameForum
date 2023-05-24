using GamersParadiseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserThreadController : ControllerBase
    {
        private readonly UserThreadManager _userThreadManager;
        public UserThreadController(UserThreadManager userThreadManager)
        {
            _userThreadManager = userThreadManager;
        }

        [HttpGet]
        public async Task<List<UserThread>> Get()
        {
            var userThreads = await _userThreadManager.GetUserThreads();
            return userThreads;
        }

        [HttpGet("{id}")]
        public async Task<UserThread> GetOneUserThread(int id)
        {
            var userThread = await _userThreadManager.GetOneUserThread(id);
            return userThread;
        }

        [HttpPost]
        public async Task CreateUserThread([FromBody] UserThread userThread)
        {
            await _userThreadManager.AddUserThread(userThread);
        }

        [HttpPut("{id}")]
        public async Task UpdateMainCategory([FromBody] UserThread userThread, int id)
        {
            await _userThreadManager.UpdateUserThread(userThread, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMainCategory(int id)
        {
            await _userThreadManager.DeleteUserThread(id);
        }

    }
}
