using System.Data;

namespace AndroidMvcServer.IDAL
{
    /// <summary>
    /// 接口层ITb_Dept
    /// </summary>
    public interface IDeptDAL
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Model.Tb_Dept model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.Tb_Dept model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete();
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.Tb_Dept GetModelById(string DepId);
        Model.Tb_Dept DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx
        string GetNickById(string userId);
        #endregion  MethodEx

        string GetAllDeptIdByUserId(string userId);

        string GetFullDeptName(string UserId);
    }
}
