using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace baomingadmin.Model
{
    public class Login
    {
        public enum LoginStatus
        {
            [Description("登录成功!")]
            SUCCESS = 1,
            [Description("登录失败,请输入用户名!")]
            ERROR_NONAME = 2,
            [Description("登录失败,请输入密码!")]
            ERROR_NOPASS = 3,
            [Description("登录失败,密码不正确!")]
            ERROR_LOGINFAIL = 4,
            [Description("登录失败,未知错误!")]
            ERROR_OTHER = 99
        }
    }
}
