using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baomingadmin.Access.User
{
    public class Login
    {
        private static string m_DesKey = "P@ss2021";
        public static Model.Login.LoginStatus LoginDo(string username, string password, ref string message)
        {
            if (String.IsNullOrEmpty(username))
            {
                return Model.Login.LoginStatus.ERROR_NONAME;
            }
            if (String.IsNullOrEmpty(password))
            {
                return Model.Login.LoginStatus.ERROR_NOPASS;
            }
            return Model.Login.LoginStatus.SUCCESS;
        }

        public static bool LoginRemember(string username, string password, ref string message)
        {
            string jsonString = "{{'username':'{0}','password':'{1}'}}";
            jsonString = String.Format(jsonString, username, password);
            jsonString = Careysoft.Basic.Public.DES.Encrypt(jsonString, m_DesKey);
            Careysoft.Basic.Public.CookieHelper.SetCookie("baomingadmin", jsonString, DateTime.Now.AddDays(30));
            return true;
        }

        public static bool LoginGetRemember(ref string username, ref string password, ref string message)
        {
            string jsonString = Careysoft.Basic.Public.CookieHelper.GetCookieValue("baomingadmin");
            jsonString = Careysoft.Basic.Public.DES.Decrypt(jsonString, m_DesKey);
            if (!String.IsNullOrEmpty(jsonString))
            {
                Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
                username = jObject["username"].ToString();
                password = jObject["password"].ToString();
            }
            return true;
        }

        public static bool LoginRememberClear(ref string message) {
            Careysoft.Basic.Public.CookieHelper.ClearCookie("baomingadmin");
            return true;
        }
    }
}
