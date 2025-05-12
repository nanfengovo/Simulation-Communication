using Simulation_Communication.Model.DTOS;
using System.ComponentModel.DataAnnotations;

namespace Simulation_Communication.Model
{
    public class User
    {
        /// <summary>
        /// id  
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public required string UserName  { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public List<Menu>? Menu { get; set; }

        /// <summary>
        /// jwt版本
        /// </summary>
        public int? JwtVersion { get; set; } = 0;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsOpen { get; set; }=true;

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }=false;

        /// <summary>
        /// 是否被锁定
        /// </summary>
        public bool IsLocked { get; set; } = false;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModified { get; set; }

        //public static implicit operator User(AddUserDTO v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
