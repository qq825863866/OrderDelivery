﻿using Microsoft.Extensions.DependencyInjection;
using Ods.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Cache
{
    public static class CacheServiceCollectionExtensions
    {
        /// <summary>
        /// 注册缓存服务，如有配置 Redis 则启用，没有则启用分布式内存缓存（DistributedMemoryCache）
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomizedCache(this IServiceCollection services)
        {
            // 根据情况，启用 Redis 或 DistributedMemoryCache
            if (AppSettings.Redis.Enabled)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = AppSettings.Redis.ConnectionString;
                    options.InstanceName = AppSettings.Redis.Instance;
                });
            }
            else
            {
                services.AddDistributedMemoryCache();
            }

            return services;
        }
    }
}
