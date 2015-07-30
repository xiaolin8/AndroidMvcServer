using System;
using System.Data;
using System.Text;
using AndroidMvcServer.DBUtility;
using AndroidMvcServer.IDAL;
using MySql.Data.MySqlClient;
namespace AndroidMvcServer.MySQLDAL
{
    /// <summary>
    /// 数据访问类:MeetingRoomDAL
    /// </summary>
    public partial class MeetingRoomDAL : IMeetingRoomDAL
    {
        public MeetingRoomDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("RoomId", "tb_meetingroom");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoomId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_meetingroom");
            strSql.Append(" where RoomId=@RoomId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@RoomId", MySqlDbType.Int32,11)			};
            parameters[0].Value = RoomId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AndroidMvcServer.Model.Tb_MeetingRoom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_meetingroom(");
            strSql.Append("RoomId,RoomName,RoomAddr,RoomCapacity,RoomDesc,CompId,Phone,Equipments)");
            strSql.Append(" values (");
            strSql.Append("@RoomId,@RoomName,@RoomAddr,@RoomCapacity,@RoomDesc,@CompId,@Phone,@Equipments)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@RoomId", MySqlDbType.Int32,11),
					new MySqlParameter("@RoomName", MySqlDbType.VarChar,50),
					new MySqlParameter("@RoomAddr", MySqlDbType.VarChar,50),
					new MySqlParameter("@RoomCapacity", MySqlDbType.Int32,11),
					new MySqlParameter("@RoomDesc", MySqlDbType.LongText),
					new MySqlParameter("@CompId", MySqlDbType.VarChar,50),
					new MySqlParameter("@Phone", MySqlDbType.VarChar,11),
					new MySqlParameter("@Equipments", MySqlDbType.VarChar,5)};
            parameters[0].Value = model.RoomId;
            parameters[1].Value = model.RoomName;
            parameters[2].Value = model.RoomAddr;
            parameters[3].Value = model.RoomCapacity;
            parameters[4].Value = model.RoomDesc;
            parameters[5].Value = model.CompId;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.Equipments;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AndroidMvcServer.Model.Tb_MeetingRoom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_meetingroom set ");
            strSql.Append("RoomName=@RoomName,");
            strSql.Append("RoomAddr=@RoomAddr,");
            strSql.Append("RoomCapacity=@RoomCapacity,");
            strSql.Append("RoomDesc=@RoomDesc,");
            strSql.Append("CompId=@CompId,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Equipments=@Equipments");
            strSql.Append(" where RoomId=@RoomId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@RoomName", MySqlDbType.VarChar,50),
					new MySqlParameter("@RoomAddr", MySqlDbType.VarChar,50),
					new MySqlParameter("@RoomCapacity", MySqlDbType.Int32,11),
					new MySqlParameter("@RoomDesc", MySqlDbType.LongText),
					new MySqlParameter("@CompId", MySqlDbType.VarChar,50),
					new MySqlParameter("@Phone", MySqlDbType.VarChar,11),
					new MySqlParameter("@Equipments", MySqlDbType.VarChar,5),
					new MySqlParameter("@RoomId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.RoomName;
            parameters[1].Value = model.RoomAddr;
            parameters[2].Value = model.RoomCapacity;
            parameters[3].Value = model.RoomDesc;
            parameters[4].Value = model.CompId;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Equipments;
            parameters[7].Value = model.RoomId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoomId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_meetingroom ");
            strSql.Append(" where RoomId=@RoomId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@RoomId", MySqlDbType.Int32,11)			};
            parameters[0].Value = RoomId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string RoomIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_meetingroom ");
            strSql.Append(" where RoomId in (" + RoomIdlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AndroidMvcServer.Model.Tb_MeetingRoom GetModel(int RoomId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoomId,RoomName,RoomAddr,RoomCapacity,RoomDesc,CompId,Phone,Equipments from tb_meetingroom ");
            strSql.Append(" where RoomId=@RoomId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@RoomId", MySqlDbType.Int32,11)			};
            parameters[0].Value = RoomId;

            AndroidMvcServer.Model.Tb_MeetingRoom model = new AndroidMvcServer.Model.Tb_MeetingRoom();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoomId,RoomName,RoomAddr,RoomCapacity,RoomDesc,CompId,Phone,Equipments ");
            strSql.Append(" FROM tb_meetingroom ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_meetingroom ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.RoomId desc");
            }
            strSql.Append(")AS Row, T.*  from tb_meetingroom T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_meetingroom";
            parameters[1].Value = "RoomId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}