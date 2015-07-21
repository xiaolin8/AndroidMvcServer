using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AndroidMvcServer.DBUtility;

namespace AndroidMvcServer.DAL
{
    /// <summary>
    /// 数据访问类:MeetingRoom
    /// </summary>
    public class MeetingRoomDAL
    {
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoomId)
        {
            return true;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AndroidMvcServer.Model.Tb_MeetingRoom model)
        {
            return true;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AndroidMvcServer.Model.Tb_MeetingRoom model)
        {
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoomId)
        {
            return false;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string RoomIdlist)
        {
            return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AndroidMvcServer.Model.Tb_MeetingRoom GetModel(int RoomId)
        {
            AndroidMvcServer.Model.Tb_MeetingRoom model = null;
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AndroidMvcServer.Model.Tb_MeetingRoom DataRowToModel(DataRow row)
        {
            AndroidMvcServer.Model.Tb_MeetingRoom model = new AndroidMvcServer.Model.Tb_MeetingRoom();
            if (row != null)
            {
                if (row["RoomId"] != null && row["RoomId"].ToString() != "")
                {
                    model.RoomId = int.Parse(row["RoomId"].ToString());
                }
                if (row["RoomName"] != null)
                {
                    model.RoomName = row["RoomName"].ToString();
                }
                if (row["RoomAddr"] != null)
                {
                    model.RoomAddr = row["RoomAddr"].ToString();
                }
                if (row["RoomCapacity"] != null && row["RoomCapacity"].ToString() != "")
                {
                    model.RoomCapacity = int.Parse(row["RoomCapacity"].ToString());
                }
                if (row["RoomDesc"] != null)
                {
                    model.RoomDesc = row["RoomDesc"].ToString();
                }
                if (row["CompId"] != null)
                {
                    model.CompId = row["CompId"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Equipments"] != null)
                {
                    model.Equipments = row["Equipments"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return 0;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoomId,RoomName,RoomAddr,RoomCapacity,RoomDesc,CompId,Phone,Equipments ");
            strSql.Append(" FROM Tb_MeetingRoom ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
