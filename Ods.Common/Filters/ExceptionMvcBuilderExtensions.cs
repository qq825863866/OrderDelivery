using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Filters
{
    public static class ExceptionMvcBuilderExtensions
    {
        public static IMvcBuilder AddExceptionFilter(this IMvcBuilder builder)
        {
            // 添加过滤器
            builder.AddMvcOptions(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
            return builder;
        }
    }
}
