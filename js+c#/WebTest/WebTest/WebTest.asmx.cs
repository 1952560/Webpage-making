using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OracleDemo;
using System.Text;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.IO;
using System.Collections;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Types;

namespace WebTest {
    /// <summary>
    /// WebTest 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
     [System.Web.Script.Services.ScriptService]
    public class WebTest : System.Web.Services.WebService {

        [WebMethod]
        public string HelloWorld() {
            return "Hello World";
        }
        [WebMethod]
        public string HelloWorld2([FromBody]string username,[FromBody]string email,[FromBody]string password) {
            //json数据转换成数组

            string selectEmail = "select email from users where email='" + email + "'";
            DataTable dt = OracleHelper.SelectBySql(selectEmail);
            if (dt.Rows.Count == 1) {
                return "This mailbox has been registered";
            }
            else {
                string values = null;
                values += "('" + username + "',";
                values += "'" + email + "',";
                values += "'" + password + "')";
                OracleHelper.Insert("users", values);
                return "registration success";
            }
        }
    }
}
