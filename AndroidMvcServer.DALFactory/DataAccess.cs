﻿using System.Reflection;
using System.Configuration;
using AndroidMvcServer.IDAL;
namespace AndroidMvcServer.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="AndroidMvcServer.MySQLDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        /// <summary>
        /// 创建tb_dept数据层接口。
        /// </summary>
        public static IDeptDAL CreateDeptDAL()
        {
            string ClassNamespace = AssemblyPath + ".DeptDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDeptDAL)objType;
        }

        /// <summary>
        /// 创建tb_group数据层接口。
        /// </summary>
        public static IGroupDAL CreateGroupDAL()
        {
            string ClassNamespace = AssemblyPath + ".GroupDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IGroupDAL)objType;
        }

        /// <summary>
        /// 创建tb_meetingroom数据层接口。
        /// </summary>
        public static IMeetingRoomDAL CreateMeetingRoomDAL()
        {
            string ClassNamespace = AssemblyPath + ".MeetingRoomDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IMeetingRoomDAL)objType;
        }

        /// <summary>
        /// 创建tb_user数据层接口。
        /// </summary>
        public static IUserDAL CreateUserDAL()
        {
            string ClassNamespace = AssemblyPath + ".UserDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IUserDAL)objType;
        }
    }
}