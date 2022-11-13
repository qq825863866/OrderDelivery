﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Components.Swagger
{
    public class AuthenticationOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Distinct();

            if (authorizeAttributes.Any())
            {
                //operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                //operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
                var bearerScheme = new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };
                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement()
                {
                    [ bearerScheme ] = Array.Empty<string>()
                }
            };
            }
        }
    }
}
