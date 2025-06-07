using Microsoft.AspNetCore.Mvc;
using Simulation_Communication.Model.DTOS;
using Menu = Simulation_Communication.Model.Menu;

namespace Simulation_Communication.ApplicationService.MenuServe
{
    /// <summary>
    /// 菜单服务接口
    /// </summary>
    public interface IMenuService
    {
        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetAllMenu();

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="addMenuDTO"></param>
        /// <returns></returns>
        public Task<bool> AddMenuAsync(AddMenuDTO addMenuDTO);
    }
}
