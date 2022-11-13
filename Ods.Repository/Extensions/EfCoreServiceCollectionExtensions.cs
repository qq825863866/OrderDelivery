using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Ods.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Repository.Extensions
{
    public static class EfCoreServiceCollectionExtensions
    {
        /// <summary>
        /// 添加仓储设置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OdsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.ConfigureWarnings(builder =>
                {
                    // 消除 https://go.microsoft.com/fwlink/?linkid=2131316
                    builder.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
                });
            });

            return services;
        }
    }
}
