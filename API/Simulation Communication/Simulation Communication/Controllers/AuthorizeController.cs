using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlugInUnit;
using Request;
using Simulation_Communication.APIHelper;
using Simulation_Communication.DB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Simulation_Communication.Controllers
{
    /// <summary>
    /// 鉴权模块
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IOptionsSnapshot<JwtSetting> _settings;

        public readonly MyDbContext _dbContext;

        public AuthorizeController(MyDbContext dbContext,IOptionsSnapshot<JwtSetting> settings)
        {
            _dbContext = dbContext;
            _settings = settings;
        }

        /// <summary>
        /// 登录鉴权
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [NotCheckJwtVersion]
        public async Task<Result> Login(CheckRequestInfo info)
        {
            // Replace the problematic line with the following:
            var isExist = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == info.userName);
            if (isExist == null)
            {
                return new Result { Code = 404, Msg = "用户名或密码错误" };
            }

            //判断是否被冻结
            if ( isExist.IsLocked)
            {
                return new Result { Code = 401, Msg = $"用户{isExist.UserName}已被冻结，请在1分后重试" };
            }

            var pwd = isExist.Password;
            //执行登录操作
            var result = pwd.Equals(info.userPwd); 
            if(result)//登录成功
            {
                //重置登录次数
                isExist.IsLocked = false;
                //isExist.JwtVersion = 0;
                _dbContext.SaveChanges();

                isExist.JwtVersion++;
                await _dbContext.SaveChangesAsync();

                //颁发令牌
                //1、声明payload
                //用户的Id和用户名
                List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier,isExist.Id.ToString()),
                new Claim(ClaimTypes.Name,isExist.UserName),
                new Claim("JwtVersion",isExist.JwtVersion.ToString())
                };

                //根据用户获取角色
                //var roles = await _dbContext.Users.GetRolesAsync(isExist);
                //foreach(var role in roles)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, role));
                //}


                //2、生成JWT
                string? key = _settings.Value.SecKey;
                DateTime expire = DateTime.Now.AddSeconds(_settings.Value.ExpireSeconds);

                byte[] sceBytes = Encoding.UTF8.GetBytes(key);
                var seckey = new SymmetricSecurityKey(sceBytes);
                var credentials = new SigningCredentials(seckey, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new JwtSecurityToken(claims:claims,issuer:_settings.Value.Issuer,audience:_settings.Value.Audience,expires:expire,signingCredentials:credentials);


                string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                //3、返回JWT
                return new Result { Code = 200, Data = jwt };

            }
            else
            {
                //记录登录失败的次数
                //await _dbContext.Users.AccessFailedAsync(isExist);
                return new Result { Code = 404, Msg = "用户名或密码错误" };
            }
        }

    }
}
