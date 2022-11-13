using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Ods.Common.Components.Authentication.Jwt;
using Ods.Common.Components.Authorization;
using Ods.Common.Components.Cache;
using Ods.Common.Components.Cors;
using Ods.Common.Components.DataValidation;
using Ods.Common.Components.DependencyInjection;
using Ods.Common.Components.Json.SystemTextJson;
using Ods.Common.Components.Logging;
using Ods.Common.Components.Swagger;
using Ods.Common.Configuration;
using Ods.Common.Filters;
using Ods.Common.Helpers;
using Ods.Common.Result;
using Ods.Common.Services;
using Ods.Common.Startup;
using Ods.Repository.Extensions;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Ods服务启动中……");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    // 读取appsetting.json配置数据初始化到AppSettings静态类上
    var configuration = builder.Configuration;
    AppSettings.Configure(configuration);

    // 日志
    //builder.Logging.ClearProviders(); // .AddConsole()
    // 设置读取指定位置的nlog.config文件
    //NLogBuilder.ConfigureNLog("XmlConfig/nlog.config");
    builder.Host.UseNLog();

    // 添加 HostedService 对静态 Helper 进行配置
    builder.Services.AddHostedService<OdsHostedService>();

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    //可以考虑放到OdsHostedService进行注册
    builder.Services.AddSingleton<INLogHelper, NLogHelper>();

    //添加请求参数校验拦截器，添加异常拦截器，添加请求记录和处理结果返回拦截器
    builder.Services.AddControllers()
        .AddDataValidation()
        .AddExceptionFilter()
        .AddAppResult();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAuthenticationSwagger(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "ods三层服务接口文档v1", Version = "v1" }));

    // 仓储层
    builder.Services.AddRepository(configuration["ConnectionStrings:SqlServer"]);

    // 服务层：添加基础服务
    builder.Services.AddBaseServices();
    // 服务层：自动添加 Service 层以 Service 结尾的服务
    builder.Services.AddAutoServices("Ods.Services");

    // JWT 认证
    builder.Services.AddJwtAuthentication();
    // 授权
    builder.Services.AddCustomizedAuthorization();
    // 替换默认 PermissionChecker
    //builder.Services.Replace(new ServiceDescriptor(typeof(IPermissionChecker), typeof(PermissionChecker), ServiceLifetime.Transient));

    // SysUser 映射为 UserInfoModel
    // MapperHelper.Map(user, result);
    // 对象映射 AutoMapper，并不是替换DI容器
    var profileAssemblies = AssemblyHelper.GetAssemblies("Ods.Services"); 
    // 这里读取整个项目程序集，也可以选择只读指定程序集，如: "Simple.Services"
    //扫描程序集profileAssemblies找到所有继承Profile的类然后进行配置
    //因为只配置了一个MapperProfile在Ods.Services那
    builder.Services.AddAutoMapper(profileAssemblies, ServiceLifetime.Singleton);

    // 缓存
    builder.Services.AddCustomizedCache();

    // JsonOptions
    builder.Services.AddCustomizedJsonOptions();

    // 跨域
    builder.Services.AddCustomizedCors();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())//设置只有再开发环境才允许打开swagger
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ods API v1");
    });

    app.UseHttpsRedirection();

    // UseCors 必须在 UseRouting 之后，UseResponseCaching、UseAuthorization 之前
    app.UseCors();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "由于发生异常，导致程序中止！");
    throw;
}
finally
{
    LogManager.Shutdown();
}
