namespace Simulation_Communication.Model.DTOS
{
    public class AddMenuDTO
    {
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 菜单顺序
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// 父菜单id
        /// </summary>
        public int? ParentsId { get; set; }

        /// <summary>
        /// 子菜单id
        /// </summary>
        //public int? SubMenu { get; set; }

        /// <summary>
        /// 关于菜单的描述
        /// </summary>
        public string? Descriptions { get; set; }

        /// <summary>
        /// 菜单地址/文件
        /// </summary>
        public string URL { get; set; }
    }
}
