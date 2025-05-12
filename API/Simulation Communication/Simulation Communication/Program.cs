
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
                // ��� JWT Bearer ��Ȩ����
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT ��Ȩͷ����ʽ: Bearer {token}",
                    Name = "Authorization",          // HTTP ͷ�����ƣ������� JWT ����һ�£�
                    In = ParameterLocation.Header,   // ����λ��Ϊ Header
                    Type = SecuritySchemeType.ApiKey,// ����Ϊ ApiKey
                    Scheme = "Bearer"                // �������ƣ��� JWT �� AuthenticationScheme һ�£�
                });

                // ȫ�ְ�ȫ���󣨱�����нӿ�Ĭ����Ҫ��Ȩ��
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"       // �����Ϸ��İ�ȫ����
                            }
                        },
                        Array.Empty<string>()        // ����Ҫָ�� Scope
                    }
                });
            });


            // ��� CORS ���Է���
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevCors", policy =>
                {
                    policy.WithOrigins("http://localhost:8889") // ǰ�˵�ַ
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // ���ǰ����Ҫ�� cookies
                });
            });

            // ǿ��ָ�� URL �Ͷ˿�
            //builder.WebHost.UseUrls("http://localhost:8888", "https://localhost:8899");

            builder.Services.AddSwaggerGen(x =>
            {
                string path = Path.Combine(System.AppContext.BaseDirectory, "Simulation Communication.xml");
                x.IncludeXmlComments(path, true);
            });

            // ��� DbContext ����
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.


            //��ȡ�����ļ���JWT��������Ϣ��Ȼ��ͨ��Configuration����ϵͳע�뵽Controller�������Ȩ
            builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("Jwt"));

            //����JWT ��Ȩ
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSetting>();
                    byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecKey);
                    var seckey = new SymmetricSecurityKey(keyBytes);

                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,//����ַ�web���Ƶ�web ����

                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,//token��������

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

            //��Ȩ
            app.UseAuthentication();
            app.UseAuthorization();


            // Ӧ�� CORS ����
            app.UseCors("DevCors");

            app.MapControllers();

            app.Run();
        }
    }
}
