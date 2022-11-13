﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Services.Account.Models
{
    /// <summary>
    /// 登陆信息
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "账号不能为空！")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空！")]
        public string Password { get; set; }

        public LoginModel(string account, string password)
        {
            Account = account;
            Password = password;
        }
    }
}
