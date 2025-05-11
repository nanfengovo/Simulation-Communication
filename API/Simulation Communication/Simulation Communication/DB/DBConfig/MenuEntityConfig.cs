using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simulation_Communication.Model;

namespace Simulation_Communication.DB.DBConfig
{
    public class MenuEntityConfig
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            //表名 —— T_User
            builder.ToTable("T_Menu");

            

        }
    }
}
