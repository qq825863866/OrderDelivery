using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ods.Common.Configuration;
using Ods.Common.Filters;
using Ods.Common.Components.Extensions;
using Ods.Common.Components.Json;
using System.Diagnostics;
using UAParser;
using Microsoft.Extensions.Logging;
using Ods.Common.Services;

namespace Ods.Common.Result
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AppResultActionFilter : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger<AppResultActionFilter> logger;

        public int Order { get; set; } = -6000;

        public AppResultActionFilter( ICurrentUserService currentUser, ILogger<AppResultActionFilter> logger)
        {
            _currentUser = currentUser;
            this.logger = logger;
        }

        /// <summary>
        /// OnActionExecuted： 进入action后，返回result前
        /// OnActionExecuting： 进入action前
        /// OnActionExecutionAsync： 进入acion前（异步）
        /// OnResultExecuted： 返回result后
        /// OnResultExecuting： 返回result前
        /// OnResultExecutionAsync： 返回result前（异步）
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
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

            ActionExecutedContext actionContext = null;
            // 进入管道的下一个过滤器，并跳过剩下动作
            if (isSkipRecord)
            {
                actionContext =  await next();
            }
            else
            {
                //操作Request.Body之前加上EnableBuffering即可
                request.EnableBuffering();
                //request.Body.Position = 0;
                request.Body.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(request.Body, Encoding.UTF8);
                string body = await reader.ReadToEndAsync();
                request.Body.Seek(0, SeekOrigin.Begin);

                var sw = new Stopwatch();
                sw.Start();
                actionContext = await next();
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
                //获取发送消息出去
                logger.LogInformation("AppResultActionFilter " + JsonHelper.Serialize(@event));
            }
            //处理返回结果
            HandleResultResponse(actionContext);
        }

        private void HandleResultResponse(ActionExecutedContext actionContext)
        {
            if (actionContext.Result != null)
            {
                actionContext.Result = AppResult.Status200OK(AppResultMessage.Status200OK, ((ObjectResult)actionContext.Result).Value);
            }
            if (actionContext.Exception != null)
            {
                // 如果是结果异常，处理成返回结果，并标记异常已处理
                actionContext.Result = AppResult.Status500InternalServerError(AppResultMessage.Status500InternalServerError, actionContext.Exception.Message + " " + actionContext.Exception.StackTrace);
                actionContext.ExceptionHandled = true;
            }
        }
    }
}
