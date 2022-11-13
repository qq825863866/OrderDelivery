using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Ods.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Cors
{
    public static class CorsServiceCollectionExtensions
    {
        /// <summary>
        /// 添加默认跨域配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomizedCors(this IServiceCollection services, Action<CorsOptions>? setupAction = null)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy( policy =>
                {
                    if (AppSettings.AllowCors.Any(c => c == "*"))
                    {
                        // 允许任意跨域
                        policy.AllowAnyOrigin();
                    }
                    else
                    {
                        // 允许指定域名
                        policy.WithOrigins(AppSettings.AllowCors).AllowAnyMethod().AllowAnyHeader();
        }
                });
            });

            // 自定义配置
            if (setupAction != null)
            {
                services.Configure<CorsOptions>(setupAction);
            }

            return services;
        }
    }
}
