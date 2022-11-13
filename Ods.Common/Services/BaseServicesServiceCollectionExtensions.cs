using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Services
{
    public static class BaseServicesServiceCollectionExtensions
    {
        /// <summary>
        /// 注册基础服务（当前用户等）
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            //获取HttpContext
            //public virtual IHttpContextAccessor HttpContextAccessor => GetService<IHttpContextAccessor>();
            //public virtual HttpContext HttpContext => HttpContextAccessor.HttpContext!;
            services.AddHttpContextAccessor();

            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
