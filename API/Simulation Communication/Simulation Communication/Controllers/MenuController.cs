using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation_Communication.ApplicationService.MenuServe;
using Simulation_Communication.DB;
using Simulation_Communication.Model;
using Simulation_Communication.Model.DTOS;
using System.Threading.Tasks;

namespace Simulation_Communication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        /// <summary>
        /// 菜单服务接口
        /// </summary>
        public readonly IMenuService _menuService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="menuService"></param>
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAllMenu()
        {
            var result = _menuService.GetAllMenu();
            if (result == null)
            {
                return NotFound("没有找到菜单");
            }
            return Ok(result);
        }


        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menuDTO"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuDTO menuDTO)
        {
            if (menuDTO == null)
            {
                return BadRequest("菜单数据不能为空");
            }
            else
            {
                var result = await _menuService.AddMenuAsync(menuDTO);
                if (result)
                {
                    return Ok("添加成功");
                }
                else
                {
                    return BadRequest("添加失败");
                }

            }
        }
    }
}
