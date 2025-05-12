
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlugInUnit;
using Simulation_Communication.DB;
using System;
using System.Text;

namespace Simulation_Communication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(options =>
            {
                // 添加 JWT Bearer 授权定义
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT 授权头，格式: Bearer {token}",
                    Name = "Authorization",          // HTTP 头的名称（必须与 JWT 配置一致）
                    In = ParameterLocation.Header,   // 参数位置为 Header
                    Type = SecuritySchemeType.ApiKey,// 类型为 ApiKey
                    Scheme = "Bearer"                // 方案名称（与 JWT 的 AuthenticationScheme 一致）
                });

                // 全局安全需求（标记所有接口默认需要授权）
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"       // 引用上方的安全定义
                            }
                        },
                        Array.Empty<string>()        // 不需要指定 Scope
                    }
                });
            });


            // 添加 CORS 策略服务
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevCors", policy =>
                {
                    policy.WithOrigins("http://localhost:8889") // 前端地址
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // 如果前端需要传 cookies
                });
            });

            // 强制指定 URL 和端口
            //builder.WebHost.UseUrls("http://localhost:8888", "https://localhost:8899");

            builder.Services.AddSwaggerGen(x =>
            {
                string path = Path.Combine(System.AppContext.BaseDirectory, "Simulation Communication.xml");
                x.IncludeXmlComments(path, true);
            });

            // 添加 DbContext 服务
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.


            //读取配置文件中JWT的配置信息，然后通过Configuration配置系统注入到Controller层进行授权
            builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("Jwt"));

            //配置JWT 鉴权
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSetting>();
                    byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecKey);
                    var seckey = new SymmetricSecurityKey(keyBytes);

                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,//代表分发web令牌的web 程序

                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,//token的受理者

                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = seckey,
                        ClockSkew = TimeSpan.FromSeconds(jwtSettings.ExpireSeconds)


                    };

                });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //鉴权
            app.UseAuthentication();
            app.UseAuthorization();


            // 应用 CORS 策略
            app.UseCors("DevCors");

            app.MapControllers();

            app.Run();
        }
    }
}
