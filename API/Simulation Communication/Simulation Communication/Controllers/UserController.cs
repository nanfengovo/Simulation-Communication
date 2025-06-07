using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation_Communication.DB;
using Simulation_Communication.Model;
using Simulation_Communication.Model.DTOS;

namespace Simulation_Communication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly MyDbContext _dbContext;

        public readonly ILogger<UserController> _logger;

        public UserController(MyDbContext dbContext, ILogger<UserController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            _logger.LogInformation($"{DateTime.Now},获取一次用户列表");
            return Ok(users);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult AddUser(AddUserDTO userDTO)
        {
            User user = new User
            {
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                CreateTime = userDTO.CreateTime,
                LastModified = DateTime.Now,
            };

            _dbContext.Users.Add(user);
            if (_dbContext.SaveChanges()>0)
            {
                return Ok("添加成功");
            }
            return BadRequest("failed");
            
        }




    }
}
