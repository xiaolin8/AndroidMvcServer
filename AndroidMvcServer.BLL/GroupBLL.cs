using System.Collections.Generic;
using System.Data;
using AndroidMvcServer.DALFactory;
using AndroidMvcServer.IDAL;
using AndroidMvcServer.Model;
namespace AndroidMvcServer.BLL
{
    /// <summary>
    /// GroupBLL
    /// </summary>
    public partial class GroupBLL
    {
        private readonly IGroupDAL dal = DataAccess.CreateGroupDAL();
        public GroupBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string groupId)
        {
            return dal.Exists(groupId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string groupId)
        {

            return dal.Delete(groupId);
        }
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string groupIdlist)
        //{
        //    return dal.DeleteList(AndroidMvcServer.Common.PageValidate.SafeLongFilter(groupIdlist, 0));
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tb_Group GetModel(string groupId)
        {

            return dal.GetModel(groupId);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public AndroidMvcServer.Model.Tb_Group GetModelByCache(string groupId)
        //{

        //    string CacheKey = "GroupBLLModel-" + groupId;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(groupId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (AndroidMvcServer.Model.Tb_Group)objModel;
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
        public List<Tb_Group> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tb_Group> DataTableToList(DataTable dt)
        {
            List<Tb_Group> modelList = new List<Tb_Group>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tb_Group model;
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

        #endregion  ExtensionMethod
    }
}