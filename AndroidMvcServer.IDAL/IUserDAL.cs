using System.Data;
using AndroidMvcServer.Model;
namespace AndroidMvcServer.IDAL
{
    /// <summary>
    /// 接口层ITb_User
    /// </summary>
    public interface IUserDAL
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string UserId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.Tb_User GetModel(string UserId);
        bool Update(Tb_User model);
        Tb_User DataRowToModel(DataRow row);
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

        #endregion  MethodEx

        Tb_User GetModelByDepId(string DepId);

        DataTable GetUsersByDepId(string DepId);
    }
}
