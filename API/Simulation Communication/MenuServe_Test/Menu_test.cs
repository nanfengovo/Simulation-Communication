using Microsoft.EntityFrameworkCore;
using Moq;
using Simulation_Communication.ApplicationService.MenuServe;
using Simulation_Communication.DB;
using Simulation_Communication.Model;

namespace MenuServe_Test
{
    public class Menu_test
    {
        private readonly IMenuService _menuService;

        private readonly MyDbContext _dbContext;
        private readonly Mock<DbSet<Menu>> _mockMenuSet;

        public Menu_test(IMenuService menuService, MyDbContext dbContext, Mock<DbSet<Menu>> mockMenuSet)
        {
            _menuService = menuService;
            _dbContext = dbContext;
            _mockMenuSet = mockMenuSet;
        }

        [Fact]
        public void GetAllMenu_Test()
        {
            // Arrange
            var testMenus = new List<Menu>
            {
                new Menu { Id = 1, Title = "Menu 1" },
                new Menu { Id = 2, Title = "Menu 2" },
                new Menu { Id = 3, Title = "Menu 3" }
            };

            // 配置模拟的DbSet返回测试数据
            var queryableMenus = testMenus.AsQueryable();
            _mockMenuSet.As<IQueryable<Menu>>()
                .Setup(m => m.Provider)
                .Returns(queryableMenus.Provider);
            _mockMenuSet.As<IQueryable<Menu>>()
                .Setup(m => m.Expression)
                .Returns(queryableMenus.Expression);
            _mockMenuSet.As<IQueryable<Menu>>()
                .Setup(m => m.ElementType)
                .Returns(queryableMenus.ElementType);
            _mockMenuSet.As<IQueryable<Menu>>()
                .Setup(m => m.GetEnumerator())
                .Returns(() => queryableMenus.GetEnumerator());

            // Act
            var result = _menuService.GetAllMenu();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("Menu 1", result[0].Title);
            Assert.Equal("Menu 2", result[1].Title);
            Assert.Equal("Menu 3", result[2].Title);
        }
    }
}