﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ods.Common.Components.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Common.Result
{
    public partial class AppResult: IActionResult
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public bool Success { get; set; }
        //public DateTime CurrentDateTime { get; set; }

        public AppResult(int code = StatusCodes.Status200OK, string? message = AppResultMessage.Status200OK, object? data = null, bool success = true)
        {
            Code = code;
            Message = message;
            Data = data;
            Success = success;
            //CurrentDateTime = DateTime.Now;
        }

        ////设置返回值序列化的格式类型
        //public static JsonSerializerSettings setting = new JsonSerializerSettings
        //{
        //    //设置为驼峰类型
        //    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
        //};
        public Task ExecuteResultAsync(ActionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            string json = string.Empty;
            if (this != null)
            {
                json = JsonHelper.Serialize(this);
            }
            json =  JsonHelper.Serialize(this);
            response.Headers["content-type"] = "application/json; charset=utf-8";
            return Task.FromResult(response.WriteAsync(json));
        }
    }

    public partial class AppResult
    {
        public static AppResult Status200OK(string? message = AppResultMessage.Status200OK, object? data = null)
        {
            return new AppResult(StatusCodes.Status200OK, message, data, true);
        }

        public static AppResult Status400BadRequest(string? message = AppResultMessage.Status400BadRequest, object? data = null)
        {
            return new AppResult(StatusCodes.Status400BadRequest, message, data, false);
        }

        public static AppResult Status401Unauthorized(string? message = AppResultMessage.Status401Unauthorized, object? data = null)
        {
            return new AppResult(StatusCodes.Status401Unauthorized, message, data, false);
        }

        public static AppResult Status403Forbidden(string? message = AppResultMessage.Status403Forbidden, object? data = null)
        {
            return new AppResult(StatusCodes.Status403Forbidden, message, data, false);
        }

        public static AppResult Status404NotFound(string? message = AppResultMessage.Status404NotFound, object? data = null)
        {
            return new AppResult(StatusCodes.Status404NotFound, message, data, false);
        }
        public static AppResult Status409Conflict(string? message = AppResultMessage.Status409Conflict, object? data = null)
        {
            return new AppResult(StatusCodes.Status409Conflict, message, data, false);
        }

        public static AppResult Status500InternalServerError(string? message = AppResultMessage.Status500InternalServerError, object? data = null)
        {
            return new AppResult(StatusCodes.Status500InternalServerError, message, data, false);
        }
    }
}
