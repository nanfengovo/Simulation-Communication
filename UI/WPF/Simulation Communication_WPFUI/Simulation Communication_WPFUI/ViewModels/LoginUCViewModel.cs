﻿using Simulation_Communication_WPFUI.DTOs;
using Simulation_Communication_WPFUI.HttpClients;
using Simulation_Communication_WPFUI.MsgEvents;
using DryIoc;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simulation_Communication_WPFUI.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// 显示注册信息命令
        /// </summary>
        public DelegateCommand ShowRegInfoCmm {  get; set; }

        /// <summary>
        /// 显示登录信息命令
        /// </summary>
        public DelegateCommand ShowLogInfoCmm { get; set; }
        public string Title { get; set; } = "PLC仿真监控平台";

        private readonly HttpRestClient HttpClient;

        //发布订阅
        private readonly IEventAggregator Aggregator;


        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginUCViewModel(HttpRestClient _HttpClient ,IEventAggregator _Aggregator)
        {
            //登录命令
            LoginCmm = new DelegateCommand(Login);

            //显示注册内容命令
            ShowRegInfoCmm = new DelegateCommand(ShowRegInfo);

            //显示登录信息命令
            ShowLogInfoCmm = new DelegateCommand(ShowLogInfo);

            //注册命令
            Regcmm = new DelegateCommand(Reg);

            //实例对象
            AccountInfoDTO = new AccountInfoDTO();

            //请求Client
            HttpClient = _HttpClient;

            Aggregator = _Aggregator;
        }

        #region 注册
        public DelegateCommand Regcmm { get;set; }

        /// <summary>
        /// 注册方法
        /// </summary>
        private void Reg()
        {
            if (string.IsNullOrEmpty(AccountInfoDTO.Name) || string.IsNullOrEmpty(AccountInfoDTO.Account) || string.IsNullOrEmpty(AccountInfoDTO.Pwd) || string.IsNullOrEmpty(AccountInfoDTO.ConfrmPwd))
            {
                //MessageBox.Show("请填写完整信息");
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("请填写完整信息");
                return;
            }

            if (AccountInfoDTO.Pwd != AccountInfoDTO.ConfrmPwd)
            {
                //MessageBox.Show("两次密码不一致");
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("两次密码不一致");
                return;
            }
            //对密码加密
            AccountInfoDTO.Pwd = Md5Helper.GetMd5(AccountInfoDTO.Pwd);
            //调用API
            ApiRequest apiRequest = new ApiRequest()
            {
                Method = RestSharp.Method.POST,
                Route = "Account/Reg",
                ContentType = "application/json",
                Parameters = AccountInfoDTO
            };

            //返回结果
            var response = HttpClient.Execute(apiRequest);

            if(response.result == 1)
            {
                //MessageBox.Show(response.Msg);
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish(response.Msg);
                //清空输入框
                AccountInfoDTO.Name = "";
                AccountInfoDTO.Account = "";
                AccountInfoDTO.Pwd = "";
                AccountInfoDTO.ConfrmPwd = "";
                //注册成功切换登录
                SelectedIndex =0;
            }
            else
            {
                //MessageBox.Show(response.Msg);
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish(response.Msg);
            }



        }


        #region 注册信息


        private AccountInfoDTO _AccountInfoDTO;

        public AccountInfoDTO AccountInfoDTO
        {
            get { return _AccountInfoDTO; }
            set
            {
                _AccountInfoDTO = value;
                RaisePropertyChanged();
            }
        }

        #endregion
        #endregion

        #region 显示内容的索引
        /// <summary>
        /// 显示内容的索引
        /// </summary>
        private int _SelectedIndex;

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// 显示注册信息
        /// </summary>
        private void ShowRegInfo()
        {
            SelectedIndex = 1;
        }
        #endregion

        private void ShowLogInfo()
        {
            SelectedIndex = 0;
        }



        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand LoginCmm { get; set; }

        

        /// <summary>
        /// 登录
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Login()
        {
            //数据的基本验证
            if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Pwd))
            {
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("登录信息不全！");
                return;
            }

            if (Account == "admin" && Pwd == "123456")
            {
                //模拟登录成功
                //MessageBox.Show("登录成功");
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("登录成功");
                DialogParameters paras = new DialogParameters();
                paras.Add("LoginName", "admin");
                RequestClose(new DialogResult(ButtonResult.OK, paras));
            }
            else
            {
                //MessageBox.Show("账号或密码错误");
                //发布消息
                Aggregator.GetEvent<MsgEvent>().Publish("账号或密码错误");
                return;
            }
                

        }

        /// <summary>
        /// 是否可以关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void Ond(IDialogParameters parameters)
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        #region 密码
        private string _pwd;

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set 
            {
                _pwd = value;
                
            }
        }
        #endregion

        #region 账号
        private string _Account;
        /// <summary> 
        /// 账号
        /// </summary>
        ///     
        public string Account
        {
            get { return _Account; }
            set
            {
                _Account = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        
    }
}
