namespace Simulation_Communication.Model.DTOS
{
    public class AddUserDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}
