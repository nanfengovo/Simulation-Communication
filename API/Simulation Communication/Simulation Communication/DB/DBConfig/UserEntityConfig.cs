using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Simulation_Communication.Model;

namespace Simulation_Communication.DB.DBConfig
{
    internal class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //表名 —— T_User
            builder.ToTable("T_User");

            //用户名是必填的最大长度是1位
            builder.Property(x => x.UserName).HasMaxLength(1).IsRequired();

            //密码是必填的最大长度是2位
            builder.Property(x => x.Password).HasMaxLength(2).IsRequired();


        }
    }
}
