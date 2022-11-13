using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ods.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Authentication.Jwt
{
    public static class JwtServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // 读取配置
            var symmetricKeyAsBase64 = AppSettings.Jwt.SecretKey;
            var issuer = AppSettings.Jwt.Issuer;
            var audience = AppSettings.Jwt.Audience;

            // 获取密钥
            var keyByteArray = Encoding.UTF8.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true, // 是否验证SecurityKey
                IssuerSigningKey = signingKey, // 拿到SecurityKey
                ValidateIssuer = true, // 是否验证Issuer
                ValidIssuer = issuer, // 发行人Issuer
                ValidateAudience = true, // 是否验证Audience
                ValidAudience = audience, // 订阅人Audience
                ValidateLifetime = true, // 是否验证失效时间
                ClockSkew = TimeSpan.FromSeconds(30), // 过期时间容错值，解决服务器端时间不同步问题（秒）
                RequireExpirationTime = true,
                NameClaimType = AuthenticationClaimTypes.UserName,
                //设置角色权限认证
                RoleClaimType = AuthenticationClaimTypes.Role,
            };

            // events
            var jwtBearerEvents = new JwtBearerEvents()
            {
                OnChallenge = async context =>
                {
                    // refresh token

                    // 
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("401");

                    // 标识处理了响应
                    context.HandleResponse();
                },
                OnForbidden = async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("403");
                }
            };

            // 开启Bearer认证
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = jwtBearerEvents;
            });

            return services;
        }
    }
}
