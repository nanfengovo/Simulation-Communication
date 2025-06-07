namespace Simulation_Communication.Model
{
    public class Menu
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int Id { get; set; }

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
        public List<Menu>? SubMenu { get; set; }

        /// <summary>
        /// 关于菜单的描述
        /// </summary>
        public string? Descriptions { get; set; }

        /// <summary>
        /// 菜单地址/文件
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelete { get; set; }



        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }=DateTime.Now;

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModified { get; set; }
    }
}
