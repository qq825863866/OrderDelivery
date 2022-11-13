using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ods.Common.Components.Cache;
using Ods.Common.Components.Json;
using Ods.Common.Components.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Startup
{
    public class OdsHostedService : IHostedService
    {
        public IHost Host { get; set; }
        private readonly ILogger<OdsHostedService> logger;
        private Timer? _timer;

        public OdsHostedService(IHost host, ILogger<OdsHostedService> logger)
        {
            Host = host;
            this.logger = logger;
        }

        /// <summary>
        /// 在不需要定时执行任务的时候，也可以在这里进行应用启动后的操作，例如创建 RabbitMQ 连接【手动狗头】(该方法只会执行一次，加了定时器才会定时执行)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("OdsHostedService StartAsync");

            var serviceProvider = Host.Services;

            // Json 配置
            var jsonOptions = serviceProvider.GetService<IOptions<JsonOptions>>();
            if (jsonOptions != null) JsonHelper.Configure(jsonOptions!.Value.JsonSerializerOptions);

            // Cache
            var cache = serviceProvider.GetService<IDistributedCache>();
            if (cache != null) CacheHelper.Configure(cache);

            // AutoMapper
            var mapper = serviceProvider.GetService<IMapper>();
            if (mapper != null) MapperHelper.Configure(mapper);

            //_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            //// serviceHelper
            //ServiceHelper.Configure(serviceProvider);

            //// old
            ////// Json 配置
            ////var jsonSerializerOptions = serviceProvider.GetService<IOptions<JsonSerializerOptions>>();
            ////JsonHelper.Configure(jsonSerializerOptions!.Value);

            //// new
            //// Json 配置
            //var jsonOptions = serviceProvider.GetService<IOptions<JsonOptions>>();
            //if (jsonOptions != null) JsonHelper.Configure(jsonOptions!.Value.JsonSerializerOptions);

            //// AutoMapper
            //var mapper = serviceProvider.GetService<IMapper>();
            //if (mapper != null) MapperHelper.Configure(mapper);

            //// Cache
            //var cache = serviceProvider.GetService<IDistributedCache>();
            //if (cache != null) CacheHelper.Configure(cache);

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("OdsHostedService StopAsync");
            return Task.CompletedTask;
        }
    }
}
