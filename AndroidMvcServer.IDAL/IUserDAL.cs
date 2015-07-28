using System;
using System.Collections.Generic;
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
        /// 增加一条数据
        /// </summary>
        bool Add(AndroidMvcServer.Model.Tb_User model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(AndroidMvcServer.Model.Tb_User model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string UserId);
        bool DeleteList(string UserIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.Tb_User GetModel(string UserId);
        AndroidMvcServer.Model.Tb_User DataRowToModel(DataRow row);
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

        Model.Tb_User GetModelByDepId(string DepId);

        List<Tb_User> GetUsersByDepId(string DepId);
    }
}
