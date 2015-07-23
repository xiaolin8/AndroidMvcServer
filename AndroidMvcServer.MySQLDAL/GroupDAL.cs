using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using AndroidMvcServer.IDAL;
using AndroidMvcServer.DBUtility;
namespace AndroidMvcServer.MySQLDAL
{
    /// <summary>
    /// 数据访问类:GroupDAL
    /// </summary>
    public partial class GroupDAL : IGroupDAL
    {
        public GroupDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string groupId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_group");
            strSql.Append(" where groupId=@groupId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@groupId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = groupId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AndroidMvcServer.Model.Tb_Group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_group(");
            strSql.Append("groupId,groupName,groupDesc,groupOwner,groupIcon,members,allowInvite,membersSize,maxUsers,isPublic)");
            strSql.Append(" values (");
            strSql.Append("@groupId,@groupName,@groupDesc,@groupOwner,@groupIcon,@members,@allowInvite,@membersSize,@maxUsers,@isPublic)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@groupId", MySqlDbType.VarChar,50),
					new MySqlParameter("@groupName", MySqlDbType.VarChar,50),
					new MySqlParameter("@groupDesc", MySqlDbType.VarChar,250),
					new MySqlParameter("@groupOwner", MySqlDbType.VarChar,15),
					new MySqlParameter("@groupIcon", MySqlDbType.Int32,11),
					new MySqlParameter("@members", MySqlDbType.VarChar,255),
					new MySqlParameter("@allowInvite", MySqlDbType.Bit,4),
					new MySqlParameter("@membersSize", MySqlDbType.Int32,11),
					new MySqlParameter("@maxUsers", MySqlDbType.Int32,11),
					new MySqlParameter("@isPublic", MySqlDbType.Bit,4)};
            parameters[0].Value = model.groupId;
            parameters[1].Value = model.groupName;
            parameters[2].Value = model.groupDesc;
            parameters[3].Value = model.groupOwner;
            parameters[4].Value = model.groupIcon;
            parameters[5].Value = model.members;
            parameters[6].Value = model.allowInvite;
            parameters[7].Value = model.membersSize;
            parameters[8].Value = model.maxUsers;
            parameters[9].Value = model.isPublic;

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
        public bool Update(AndroidMvcServer.Model.Tb_Group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_group set ");
            strSql.Append("groupName=@groupName,");
            strSql.Append("groupDesc=@groupDesc,");
            strSql.Append("groupOwner=@groupOwner,");
            strSql.Append("groupIcon=@groupIcon,");
            strSql.Append("members=@members,");
            strSql.Append("allowInvite=@allowInvite,");
            strSql.Append("membersSize=@membersSize,");
            strSql.Append("maxUsers=@maxUsers,");
            strSql.Append("isPublic=@isPublic");
            strSql.Append(" where groupId=@groupId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@groupName", MySqlDbType.VarChar,50),
					new MySqlParameter("@groupDesc", MySqlDbType.VarChar,250),
					new MySqlParameter("@groupOwner", MySqlDbType.VarChar,15),
					new MySqlParameter("@groupIcon", MySqlDbType.Int32,11),
					new MySqlParameter("@members", MySqlDbType.VarChar,255),
					new MySqlParameter("@allowInvite", MySqlDbType.Bit,4),
					new MySqlParameter("@membersSize", MySqlDbType.Int32,11),
					new MySqlParameter("@maxUsers", MySqlDbType.Int32,11),
					new MySqlParameter("@isPublic", MySqlDbType.Bit,4),
					new MySqlParameter("@groupId", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.groupName;
            parameters[1].Value = model.groupDesc;
            parameters[2].Value = model.groupOwner;
            parameters[3].Value = model.groupIcon;
            parameters[4].Value = model.members;
            parameters[5].Value = model.allowInvite;
            parameters[6].Value = model.membersSize;
            parameters[7].Value = model.maxUsers;
            parameters[8].Value = model.isPublic;
            parameters[9].Value = model.groupId;

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
        public bool Delete(string groupId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_group ");
            strSql.Append(" where groupId=@groupId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@groupId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = groupId;

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
        public bool DeleteList(string groupIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_group ");
            strSql.Append(" where groupId in (" + groupIdlist + ")  ");
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
        public AndroidMvcServer.Model.Tb_Group GetModel(string groupId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select groupId,groupName,groupDesc,groupOwner,groupIcon,members,allowInvite,membersSize,maxUsers,isPublic from tb_group ");
            strSql.Append(" where groupId=@groupId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@groupId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = groupId;

            AndroidMvcServer.Model.Tb_Group model = new AndroidMvcServer.Model.Tb_Group();
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
        public AndroidMvcServer.Model.Tb_Group DataRowToModel(DataRow row)
        {
            AndroidMvcServer.Model.Tb_Group model = new AndroidMvcServer.Model.Tb_Group();
            if (row != null)
            {
                if (row["groupId"] != null)
                {
                    model.groupId = row["groupId"].ToString();
                }
                if (row["groupName"] != null)
                {
                    model.groupName = row["groupName"].ToString();
                }
                if (row["groupDesc"] != null)
                {
                    model.groupDesc = row["groupDesc"].ToString();
                }
                if (row["groupOwner"] != null)
                {
                    model.groupOwner = row["groupOwner"].ToString();
                }
                if (row["groupIcon"] != null && row["groupIcon"].ToString() != "")
                {
                    model.groupIcon = int.Parse(row["groupIcon"].ToString());
                }
                if (row["members"] != null)
                {
                    model.members = row["members"].ToString();
                }
                if (row["allowInvite"] != null && row["allowInvite"].ToString() != "")
                {
                    model.allowInvite = int.Parse(row["allowInvite"].ToString());
                }
                if (row["membersSize"] != null && row["membersSize"].ToString() != "")
                {
                    model.membersSize = int.Parse(row["membersSize"].ToString());
                }
                if (row["maxUsers"] != null && row["maxUsers"].ToString() != "")
                {
                    model.maxUsers = int.Parse(row["maxUsers"].ToString());
                }
                if (row["isPublic"] != null && row["isPublic"].ToString() != "")
                {
                    model.isPublic = int.Parse(row["isPublic"].ToString());
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
            strSql.Append("select groupId,groupName,groupDesc,groupOwner,groupIcon,members,allowInvite,membersSize,maxUsers,isPublic ");
            strSql.Append(" FROM tb_group ");
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
            strSql.Append("select count(1) FROM tb_group ");
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
                strSql.Append("order by T.groupId desc");
            }
            strSql.Append(")AS Row, T.*  from tb_group T ");
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
            parameters[0].Value = "tb_group";
            parameters[1].Value = "groupId";
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