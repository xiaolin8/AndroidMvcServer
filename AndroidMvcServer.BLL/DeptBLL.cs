using System;
using System.Data;
using System.Collections.Generic;
using AndroidMvcServer.DALFactory;
using AndroidMvcServer.IDAL;
namespace AndroidMvcServer.BLL
{
    /// <summary>
    /// DeptBLL
    /// </summary>
    public partial class DeptBLL
    {
        private readonly IDeptDAL dal = DataAccess.CreateDeptDAL();
        public DeptBLL()
        { }
        #region  BasicMethod
        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(string DepId)
        //{
        //    return dal.Exists(DepId);
        //}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AndroidMvcServer.Model.Tb_Dept model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AndroidMvcServer.Model.Tb_Dept model)
        {
            return dal.Update(model);
        }

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(string DepId)
        //{

        //    return dal.Delete(DepId);
        //}
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string DepIdlist)
        //{
        //    return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(DepIdlist, 0));
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AndroidMvcServer.Model.Tb_Dept GetDeptById(string DepId)
        {
            return dal.GetModelById(DepId);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public AndroidMvcServer.Model.Tb_Dept GetModelByCache(string DepId)
        //{

        //    string CacheKey = "Tb_DeptModel-" + DepId;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(DepId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (AndroidMvcServer.Model.Tb_Dept)objModel;
        //}

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
        public List<AndroidMvcServer.Model.Tb_Dept> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AndroidMvcServer.Model.Tb_Dept> DataTableToList(DataTable dt)
        {
            List<AndroidMvcServer.Model.Tb_Dept> modelList = new List<AndroidMvcServer.Model.Tb_Dept>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AndroidMvcServer.Model.Tb_Dept model;
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

        /// <summary>根据ParDepId获取子部门ID列表
        /// </summary>
        public List<string> GetDeptsByParDepId(string ParDepId)
        {
            List<string> depList = new List<string>();
            DataSet DSet = dal.GetList("ParDepId='" + ParDepId + "'");
            if (DSet != null)
            {
                if (DSet.Tables[0] != null)
                {
                    for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
                    {
                        DataRowView rowview = DSet.Tables[0].DefaultView[i];
                        string DepId = rowview["DepId"].ToString();
                        depList.Add(DepId);
                    }
                }
                return depList;
            }
            return null;
        }

        public string GetNickById(string userId)
        {
            return dal.GetNickById(userId);
        }
        #endregion  ExtensionMethod

    }
}