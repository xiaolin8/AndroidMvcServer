using System.Data;
namespace AndroidMvcServer.IDAL
{
    /// <summary>
    /// 接口层Tb_MeetingRoom
    /// </summary>
    public interface IMeetingRoomDAL
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int RoomId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(AndroidMvcServer.Model.Tb_MeetingRoom model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(AndroidMvcServer.Model.Tb_MeetingRoom model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int RoomId);
        bool DeleteList(string RoomIdlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        AndroidMvcServer.Model.Tb_MeetingRoom GetModel(int RoomId);
        AndroidMvcServer.Model.Tb_MeetingRoom DataRowToModel(DataRow row);
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