﻿using System.Data;
namespace AndroidMvcServer.IDAL
{
    /// <summary>
    /// 接口层ITb_Group
    /// </summary>
    public interface IGroupDAL
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string groupId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(AndroidMvcServer.Model.Tb_Group model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(AndroidMvcServer.Model.Tb_Group model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string groupId);
        bool DeleteList(string groupIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        AndroidMvcServer.Model.Tb_Group GetModel(string groupId);
        AndroidMvcServer.Model.Tb_Group DataRowToModel(DataRow row);
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
    }
}
