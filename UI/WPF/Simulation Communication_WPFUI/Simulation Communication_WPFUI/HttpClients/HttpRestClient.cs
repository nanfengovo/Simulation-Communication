using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Simulation_Communication_WPFUI.HttpClients
{
    /// <summary>
    /// 调用api工具类
    /// </summary>
    public class HttpRestClient
    {
        //客户端
        private readonly RestClient Client;

        private readonly string baseUrl = "http://localhost:5226/api/";
        /// <summary>
        /// 构造方法
        /// </summary>
        public HttpRestClient()
        {
            Client = new RestClient();
        }



        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="apiRequest">请求数据</param>
        /// <returns>接收数据</returns>
        public ApiReponse Execute(ApiRequest apiRequest)
        {
            var request = new RestRequest(apiRequest.Route, apiRequest.Method);
            //请求方式
            //var request = new RestRequest(apiRequest.Method);
            //内容类型
            request.AddHeader("Content-Type", apiRequest.ContentType);

            //如果存在请求参数-添加到请求体中
            if(apiRequest.Parameters != null)
            {
                request.AddJsonBody(apiRequest.Parameters); // 关键修改：直接添加JSON对象
                //SerializeObject 将对象转为字符串（JSON序列化）
                //request.AddParameter("param",JsonConvert.SerializeObject(apiRequest.Parameters),ParameterType.RequestBody);
            }

            //请求地址
            // 4. 安全拼接URL
            // 确保 Client 已初始化
            var Client = new RestClient();

            // 设置基础 URL（注意：只设置基础部分，不包括端点路径）
            //Client.BaseUrl = new Uri(baseUrl);
            Client.BaseUrl = new Uri(baseUrl + apiRequest.Route); // 直接在这里设置完整的 URL
                                                                    // 创建请求时指定完整端点

            //Client.BaseUrl = new Uri(baseUrl+ apiRequest.Route);

            //发送请求
            var response = Client.Execute(request);

            //返回结果
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //DeserializeObject 反序列化 json -> 对象
                return JsonConvert.DeserializeObject<ApiReponse>(response.Content);
            }
            else
            {
                //如果请求失败，返回错误信息
                return new ApiReponse()
                {
                    //ResultCode = -99,
                    result = -99,
                    Msg = response.ErrorMessage,
                };
            }

        }
    }
}
