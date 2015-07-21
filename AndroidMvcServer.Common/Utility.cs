using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidMvcServer.Common
{
    /// <summary>
    /// 是一个工具类，提供了一些基础的功能。其中的方法一般定义为静态方法，可直接在其它地方使用。
    /// </summary>
    public sealed class Utility
    {
        /// <summary>
        /// 获取配置文件中的连接字符串
        /// <remarks>需要在配置文件中指定AppSettins.ConnectionString项</remarks>
        /// </summary>
        /// <returns>连接字符串</returns>
        public static string GetConnectionString()
        {
            string sTmp = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnectionStr"].ToString();
            //可能需要进行一些解密的操作
            return sTmp;
        }

        /// <summary>
        /// 获得配置文件中指定的值。
        /// </summary>
        /// <param name="sKey">配置文件中AppSettings节中数据节点键值</param>
        /// <returns></returns>
        public static string GetAppSetting(string sKey)
        {
            return System.Configuration.ConfigurationManager.AppSettings[sKey];
        }
    }
}
