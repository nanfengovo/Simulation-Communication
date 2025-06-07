using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Communication_WPFUI.HttpClients
{
    /// <summary>
    /// 接收模型
    /// </summary>
    public class ApiReponse
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        //public int ResultCode { get; set; }
        public int result { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? description { get; set; }
        
        /// <summary>
        /// 结果信息
        /// </summary>
        public string? Msg { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public object? ResultData { get; set; }
    }
}
