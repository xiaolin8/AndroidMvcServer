using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AndroidMvcServer.Common;
using AndroidMvcServer.DALFactory;
using AndroidMvcServer.IDAL;
using AndroidMvcServer.Model;
namespace AndroidMvcServer.BLL
{
    /// <summary>
    /// UserBLL
    /// </summary>
    public partial class UserBLL
    {
        private readonly IUserDAL dal = DataAccess.CreateUserDAL();
        public UserBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserId)
        {
            return dal.Exists(UserId);
        }

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string UserIdlist)
        //{
        //    return dal.DeleteList(AndroidMvcServer.Common.PageValidate.SafeLongFilter(UserIdlist, 0));
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Tb_User GetModel(string UserId)
        {
            return dal.GetModel(UserId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Tb_User GetModelByCache(string UserId)
        {

            string CacheKey = "UserBLLModel-" + UserId;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserId);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Tb_User)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tb_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tb_User> DataTableToList(DataTable dt)
        {
            List<Tb_User> modelList = new List<Tb_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tb_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    return dal.GetRecordCount(strWhere);
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据用户ID列表返回用户信息表
        /// </summary>
        /// <param name="userIdList"></param>
        /// <returns></returns>
        public DataTable GetUsersByUserIds(List<string> userIdList)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (string s in userIdList)
            {
                strSql.Append(" UserId = '" + s + "' OR ");
            }
            string sql = strSql.ToString().Remove(strSql.Length - 4, 3);
            DataSet DSet = GetList(sql);
            if (DSet != null)
            {
                if (DSet.Tables[0] != null)
                {
                    return DSet.Tables[0];
                }
                return null;
            }
            return null;
        }

        //根据DepId获取所有用户数据
        public DataTable GetUsersByDepId(string DepId)
        {
            return dal.GetUsersByDepId(DepId);
        }

        #endregion  ExtensionMethod


        public int GetPerPhoto(string UserId)
        {
            Model.Tb_User user = GetModel(UserId);
            if (user != null)
                return (Int32)user.HeadPic;
            return -1;
        }

        public string GetNickById(string userName)
        {
            Model.Tb_User user = GetModel(userName);
            if (user != null)
                return user.UserName;
            return "";
        }
    }
}