using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using AndroidMvcServer.DBUtility;
using AndroidMvcServer.IDAL;

namespace AndroidMvcServer.MySQLDAL
{
    /// <summary>
    /// 数据访问类:DeptDAL
    /// </summary>
    public partial class DeptDAL : IDeptDAL
    {
        public DeptDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DepId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_dept");
            strSql.Append(" where DepId=@DepId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DepId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = DepId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AndroidMvcServer.Model.Tb_Dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_dept(");
            strSql.Append("DepId,DepName,ParDepId,DisplayIndex,DirectorId,DepEmail,Status,IsLeaf,Comment)");
            strSql.Append(" values (");
            strSql.Append("@DepId,@DepName,@ParDepId,@DisplayIndex,@DirectorId,@DepEmail,@Status,@IsLeaf,@Comment)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DepId", MySqlDbType.VarChar,50),
					new MySqlParameter("@DepName", MySqlDbType.VarChar,50),
					new MySqlParameter("@ParDepId", MySqlDbType.VarChar,50),
					new MySqlParameter("@DisplayIndex", MySqlDbType.Int32,11),
					new MySqlParameter("@DirectorId", MySqlDbType.VarChar,15),
					new MySqlParameter("@DepEmail", MySqlDbType.VarChar,200),
					new MySqlParameter("@Status", MySqlDbType.Int32,11),
					new MySqlParameter("@IsLeaf", MySqlDbType.Int16,4),
					new MySqlParameter("@Comment", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.DepId;
            parameters[1].Value = model.DepName;
            parameters[2].Value = model.ParDepId;
            parameters[3].Value = model.DisplayIndex;
            parameters[4].Value = model.DirectorId;
            parameters[5].Value = model.DepEmail;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.IsLeaf;
            parameters[8].Value = model.Comment;

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
        public bool Update(AndroidMvcServer.Model.Tb_Dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_dept set ");
            strSql.Append("DepName=@DepName,");
            strSql.Append("ParDepId=@ParDepId,");
            strSql.Append("DisplayIndex=@DisplayIndex,");
            strSql.Append("DirectorId=@DirectorId,");
            strSql.Append("DepEmail=@DepEmail,");
            strSql.Append("Status=@Status,");
            strSql.Append("IsLeaf=@IsLeaf,");
            strSql.Append("Comment=@Comment");
            strSql.Append(" where DepId=@DepId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DepName", MySqlDbType.VarChar,50),
					new MySqlParameter("@ParDepId", MySqlDbType.VarChar,50),
					new MySqlParameter("@DisplayIndex", MySqlDbType.Int32,11),
					new MySqlParameter("@DirectorId", MySqlDbType.VarChar,15),
					new MySqlParameter("@DepEmail", MySqlDbType.VarChar,200),
					new MySqlParameter("@Status", MySqlDbType.Int32,11),
					new MySqlParameter("@IsLeaf", MySqlDbType.Bit,1),
					new MySqlParameter("@Comment", MySqlDbType.VarChar,255),
					new MySqlParameter("@DepId", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.DepName;
            parameters[1].Value = model.ParDepId;
            parameters[2].Value = model.DisplayIndex;
            parameters[3].Value = model.DirectorId;
            parameters[4].Value = model.DepEmail;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.IsLeaf;
            parameters[7].Value = model.Comment;
            parameters[8].Value = model.DepId;

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
        public bool Delete(string DepId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_dept ");
            strSql.Append(" where DepId=@DepId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DepId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = DepId;

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
        public bool DeleteList(string DepIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_dept ");
            strSql.Append(" where DepId in (" + DepIdlist + ")  ");
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
        public AndroidMvcServer.Model.Tb_Dept GetModel(string DepId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DepId,DepName,ParDepId,DisplayIndex,DirectorId,DepEmail,Status,IsLeaf,Comment from tb_dept ");
            strSql.Append(" where DepId=@DepId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DepId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = DepId;

            AndroidMvcServer.Model.Tb_Dept model = new AndroidMvcServer.Model.Tb_Dept();
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
        public AndroidMvcServer.Model.Tb_Dept DataRowToModel(DataRow row)
        {
            AndroidMvcServer.Model.Tb_Dept model = new AndroidMvcServer.Model.Tb_Dept();
            if (row != null)
            {
                if (row["DepId"] != null)
                {
                    model.DepId = row["DepId"].ToString();
                }
                if (row["DepName"] != null)
                {
                    model.DepName = row["DepName"].ToString();
                }
                if (row["ParDepId"] != null)
                {
                    model.ParDepId = row["ParDepId"].ToString();
                }
                if (row["DisplayIndex"] != null && row["DisplayIndex"].ToString() != "")
                {
                    model.DisplayIndex = int.Parse(row["DisplayIndex"].ToString());
                }
                if (row["DirectorId"] != null)
                {
                    model.DirectorId = row["DirectorId"].ToString();
                }
                if (row["DepEmail"] != null)
                {
                    model.DepEmail = row["DepEmail"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["IsLeaf"] != null && row["IsLeaf"].ToString() != "")
                {
                    model.IsLeaf = int.Parse(row["IsLeaf"].ToString());
                }
                if (row["Comment"] != null)
                {
                    model.Comment = row["Comment"].ToString();
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
            strSql.Append("select DepId,DepName,ParDepId,DisplayIndex,DirectorId,DepEmail,Status,IsLeaf,Comment ");
            strSql.Append(" FROM tb_dept ");
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
            strSql.Append("select count(1) FROM tb_dept ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.DepId desc");
            }
            strSql.Append(")AS Row, T.*  from tb_dept T ");
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
            parameters[0].Value = "tb_dept";
            parameters[1].Value = "DepId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string GetNickById(string userId)
        {
            object o = DbHelperMySQL.GetSingle("SELECT UserName FROM Tb_User WHERE UserId = '" + userId + "'");
            if (o != null)
                return o.ToString();
            return "";
        }
        #endregion  ExtensionMethod


        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public Model.Tb_Dept GetModelById(string DepId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DepId,DepName,ParDepId,DisplayIndex,DirectorId,DepEmail,Status,IsLeaf,Comment from tb_dept ");
            strSql.Append(" where DepId=@DepId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@DepId", MySqlDbType.VarChar,50)			};
            parameters[0].Value = DepId;

            AndroidMvcServer.Model.Tb_Dept model = new AndroidMvcServer.Model.Tb_Dept();
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
    }
}