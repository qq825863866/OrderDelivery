using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Ods.Common.Components.Extensions;
using Ods.Common.Components.Json;
using Ods.Common.Configuration;
using Ods.Common.Result;
using Ods.Common.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace Ods.Common.Filters
{
    public class RequestActionFilter : IAsyncActionFilter, IOrderedFilter
    {
        //private readonly IEventPublisher _publisher;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger<RequestActionFilter> logger;

        public int Order { get; set; } = -8000;

        public RequestActionFilter(ICurrentUserService currentUser, ILogger<RequestActionFilter> logger)
        {
            _currentUser = currentUser;
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool isSkipRecord = false;
            var httpContext = context.HttpContext;
            var request = context.HttpContext.Request;
            var headers = request.Headers;
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            // 判断是否需要跳过
            if (!AppSettings.RecordRequest.IsEnabled) isSkipRecord = true;
            if (actionDescriptor == null) isSkipRecord = true;
            if (AppSettings.RecordRequest.IsSkipGetMethod && request.Method.ToUpper() == "GET") isSkipRecord = true;

            foreach (var metadata in actionDescriptor!.EndpointMetadata)
            {
                if (metadata is DisabledRequestRecordAttribute)
                {
                    isSkipRecord = true;
                }
            }

            // 进入管道的下一个过滤器，并跳过剩下动作
            if (isSkipRecord)
            {
                await next();
                return;
            }

            //request.Body.Position = 0;
            request.Body.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(request.Body, Encoding.UTF8);
            string body = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);

            var sw = new Stopwatch();
            sw.Start();
            var actionContext = await next();
            sw.Stop();

            bool isSuccess = actionContext.Exception == null; // 没有异常即认为请求成功
            var clientInfo = headers.ContainsKey("User-Agent") ? Parser.GetDefault().Parse(headers["User-Agent"]) : null;
            string name = actionDescriptor == null ? "" : actionDescriptor.MethodInfo.GetSummary();

            string result = "";
            string message = "";

            // 目前只处理 ObjectResult
            if (actionContext.Result is ObjectResult objectResult)
            {
                // 正常接口都是 ObjectResult
                result = JsonHelper.Serialize(objectResult.Value);
                if (objectResult.Value is AppResult appResult)
                {
                    message = appResult.Message ?? "";
                }
            }
            var @event = new
            {
                Name = name,
                Message = message,
                Account = _currentUser.UserName,
                IsSuccess = isSuccess,
                Browser = clientInfo?.UA.Family + clientInfo?.UA.Major,
                OperatingSystem = clientInfo?.OS.Family + clientInfo?.OS.Major,
                Ip = httpContext.GetRequestIPv4(),
                Url = request.GetRequestUrlAddress(),
                Path = request.Path,
                ClassName = context.Controller.ToString(),
                MethodName = actionDescriptor?.ActionName,
                RequestMethod = request.Method,
                //Parameter = context.ActionArguments.Count < 1 ? string.Empty : JsonHelper.Serialize(context.ActionArguments),
                Body = body,
                Result = result,
                ElapsedTime = sw.ElapsedMilliseconds,
                OperatingTime = DateTimeOffset.Now,
            };
            logger.LogInformation("RequestActionFilter " + JsonHelper.Serialize(@event));

            //if(actionContext.Exception is AppResultException appResultException)
            //{
            //    // 如果是 AppResultException 说明是统一返回
            //    result = JsonHelper.Serialize(appResultException.AppResult);
            //    message = appResultException.AppResult.Message ?? "";
            //}
            //else if (actionContext.Result is JsonResult jsonResult)
            //{
            //    result = JsonHelper.Serialize(jsonResult.Value);
            //}

            //var @event = new RequestEvent()
            //{
            //    Name = name,
            //    Message = message,
            //    Account = _currentUser.UserName,
            //    IsSuccess = isSuccess,
            //    Browser = clientInfo?.UA.Family + clientInfo?.UA.Major,
            //    OperatingSystem = clientInfo?.OS.Family + clientInfo?.OS.Major,
            //    Ip = httpContext.GetRequestIPv4(),
            //    Url = request.GetRequestUrlAddress(),
            //    Path = request.Path,
            //    ClassName = context.Controller.ToString(),
            //    MethodName = actionDescriptor?.ActionName,
            //    RequestMethod = request.Method,
            //    //Parameter = context.ActionArguments.Count < 1 ? string.Empty : JsonHelper.Serialize(context.ActionArguments),
            //    Body = body,
            //    Result = result,
            //    ElapsedTime = sw.ElapsedMilliseconds,
            //    OperatingTime = DateTimeOffset.Now,
            //};

            //await _publisher.PublishAsync(@event);
        }
    }
}
