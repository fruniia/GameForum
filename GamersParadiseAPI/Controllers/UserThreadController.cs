using GamersParadiseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamersParadiseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserThreadController : ControllerBase
    {
        private static List<UserThread> _userThreads;

        [HttpGet]
        public async Task<List<UserThread>> Get()
        {
            _userThreads = await UserThreadManager.GetAllUserThreads();
            return _userThreads;
        }

        [HttpGet("{id}")]
        public async Task<UserThread> GetOneUserThread(int id)
        {
            if (_userThreads is null)
            {
                _userThreads = await UserThreadManager.GetAllUserThreads();
            }
            var userThread = _userThreads.Where(x => x.Id == id).FirstOrDefault();

            return userThread;
        }

        [HttpPost]
        public async Task CreateUserThread([FromBody] UserThread userThread)
        {
            if (_userThreads is null)
            {
                _userThreads = await UserThreadManager.GetAllUserThreads();
            }

            userThread.Id = _userThreads.TakeLast(1).Select(x => x.Id).FirstOrDefault() + 1;

            _userThreads.Add(userThread);
        }

        [HttpPut("{id}")]
        public async Task UpdateUserThread([FromBody] UserThread userThread, int id)
        {
            if (_userThreads is null)
            {
                _userThreads = await UserThreadManager.GetAllUserThreads();
            }

            var existingUserThread = _userThreads.Where(x => x.Id == id).FirstOrDefault();
            if (userThread is not null)
            {
                existingUserThread.Header = userThread.Header;
                existingUserThread.Content = userThread.Content;
                existingUserThread.Score = userThread.Score;

            }

        }

        [HttpDelete("{id}")]
        public async Task DeleteUserThread(int id)
        {
            if (_userThreads is null)
            {
                _userThreads = await UserThreadManager.GetAllUserThreads();

            }

            if (id <= _userThreads.Count)
            {
                var deleteUserThread = _userThreads.Where(x => x.Id == id).FirstOrDefault();
                _userThreads.Remove(deleteUserThread);
            }
        }
    }
}
