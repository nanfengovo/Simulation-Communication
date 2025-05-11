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

        public UserController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();   
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
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
