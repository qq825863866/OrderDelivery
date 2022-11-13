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
logger.Debug("Ods���������С���");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    // ��ȡappsetting.json�������ݳ�ʼ����AppSettings��̬����
    var configuration = builder.Configuration;
    AppSettings.Configure(configuration);

    // ��־
    //builder.Logging.ClearProviders(); // .AddConsole()
    // ���ö�ȡָ��λ�õ�nlog.config�ļ�
    //NLogBuilder.ConfigureNLog("XmlConfig/nlog.config");
    builder.Host.UseNLog();

    // ��� HostedService �Ծ�̬ Helper ��������
    builder.Services.AddHostedService<OdsHostedService>();

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    //���Կ��Ƿŵ�OdsHostedService����ע��
    builder.Services.AddSingleton<INLogHelper, NLogHelper>();

    //����������У��������������쳣����������������¼�ʹ���������������
    builder.Services.AddControllers()
        .AddDataValidation()
        .AddExceptionFilter()
        .AddAppResult();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAuthenticationSwagger(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "ods�������ӿ��ĵ�v1", Version = "v1" }));

    // �ִ���
    builder.Services.AddRepository(configuration["ConnectionStrings:SqlServer"]);

    // ����㣺��ӻ�������
    builder.Services.AddBaseServices();
    // ����㣺�Զ���� Service ���� Service ��β�ķ���
    builder.Services.AddAutoServices("Ods.Services");

    // JWT ��֤
    builder.Services.AddJwtAuthentication();
    // ��Ȩ
    builder.Services.AddCustomizedAuthorization();
    // �滻Ĭ�� PermissionChecker
    //builder.Services.Replace(new ServiceDescriptor(typeof(IPermissionChecker), typeof(PermissionChecker), ServiceLifetime.Transient));

    // SysUser ӳ��Ϊ UserInfoModel
    // MapperHelper.Map(user, result);
    // ����ӳ�� AutoMapper���������滻DI����
    var profileAssemblies = AssemblyHelper.GetAssemblies("Ods.Services"); 
    // �����ȡ������Ŀ���򼯣�Ҳ����ѡ��ֻ��ָ�����򼯣���: "Simple.Services"
    //ɨ�����profileAssemblies�ҵ����м̳�Profile����Ȼ���������
    //��Ϊֻ������һ��MapperProfile��Ods.Services��
    builder.Services.AddAutoMapper(profileAssemblies, ServiceLifetime.Singleton);

    // ����
    builder.Services.AddCustomizedCache();

    // JsonOptions
    builder.Services.AddCustomizedJsonOptions();

    // ����
    builder.Services.AddCustomizedCors();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())//����ֻ���ٿ��������������swagger
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ods API v1");
    });

    app.UseHttpsRedirection();

    // UseCors ������ UseRouting ֮��UseResponseCaching��UseAuthorization ֮ǰ
    app.UseCors();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "���ڷ����쳣�����³�����ֹ��");
    throw;
}
finally
{
    LogManager.Shutdown();
}
