﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Communication_WPFUI.HttpClients
{
    /// <summary>
    /// 请求模型
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// 请求的地址
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public object Parameters { get; set; }

        /// <summary>
        /// 发送的数据类型
        /// </summary>
        public string ContentType { get; set; } = "application/json";
    }
}
