using Microsoft.AspNetCore.Mvc.Filters;
using Ods.Common.Components.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Filters
{
    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly INLogHelper logHelper;
        public ExceptionFilter(INLogHelper logHelper)
        {
            this.logHelper = logHelper;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            // 如果异常没有被处理，则进行处理
            if (!context.ExceptionHandled)
            {
                // 记录错误信息
                logHelper.LogError(context.Exception);
                // 设置为true，表示异常已经被处理了，其它捕获异常的地方就不会再处理了
                context.ExceptionHandled = true;
            }
            return Task.CompletedTask;
        }
    }
}
