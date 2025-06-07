using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Simulation_Communication.DB;
using Simulation_Communication.Model.DTOS;
using Menu = Simulation_Communication.Model.Menu;

namespace Simulation_Communication.ApplicationService.MenuServe
{
    /// <summary>
    /// 菜单服务实现类
    /// </summary>
    public class MenuService : IMenuService
    {

        /// <summary>
        /// 数据上下文
        /// </summary>
        private readonly MyDbContext _myDbContext;

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<MenuService> _logger;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="myDbContext"></param>
        public MenuService(MyDbContext myDbContext, ILogger<MenuService> logger)
        {
            _myDbContext = myDbContext;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有的菜单
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Menu> GetAllMenu()
        {
            var menus = _myDbContext.Menus.ToList();
            return menus;
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="addMenuDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddMenuAsync(AddMenuDTO addMenuDTO)
        {
            // 添加参数校验（推荐）
            if (addMenuDTO == null)
                throw new ArgumentNullException(nameof(addMenuDTO));

            // 关键字段验证
            if (string.IsNullOrWhiteSpace(addMenuDTO.Title))
                return false;
            //DTO转为实体类
            var menu = new Model.Menu
            {
                Icon = addMenuDTO.Icon,
                Title = addMenuDTO.Title.Trim(),
                Index = addMenuDTO.Index,
                ParentsId = addMenuDTO.ParentsId,
                Descriptions = addMenuDTO.Descriptions,
                URL = addMenuDTO.URL,
                IsDelete = false,
                CreateTime = DateTime.Now
            };
            //添加菜单到数据库
            _myDbContext.Menus.Add(menu);
            //开启事务处理，确保数据一致性
            await using var transaction = await _myDbContext.Database.BeginTransactionAsync();
            try
            {
                int affectedRows = await _myDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                if (affectedRows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "添加菜单失败");
                return false;
            }
            
        }

        
    }
}
