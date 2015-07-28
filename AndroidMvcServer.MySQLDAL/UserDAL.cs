using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using AndroidMvcServer.IDAL;
using AndroidMvcServer.DBUtility;
using System.Collections.Generic;
using AndroidMvcServer.Model;//Please add references
namespace AndroidMvcServer.MySQLDAL
{
    /// <summary>
    /// 数据访问类:UserDAL
    /// </summary>
    public partial class UserDAL : IUserDAL
    {
        public UserDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user");
            strSql.Append(" where UserId=@UserId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserId", MySqlDbType.VarChar,15)			};
            parameters[0].Value = UserId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AndroidMvcServer.Model.Tb_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user(");
            strSql.Append("UserId,UserName,EnglishName,Pwd,Status,DeptId,Gender,Signature,HeadPic,CellPhone,OfficePhone,Email,Position,DisplayIndex,Comment)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@UserName,@EnglishName,@Pwd,@Status,@DeptId,@Gender,@Signature,@HeadPic,@CellPhone,@OfficePhone,@Email,@Position,@DisplayIndex,@Comment)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserId", MySqlDbType.VarChar,15),
					new MySqlParameter("@UserName", MySqlDbType.VarChar,10),
					new MySqlParameter("@EnglishName", MySqlDbType.VarChar,15),
					new MySqlParameter("@Pwd", MySqlDbType.VarChar,32),
					new MySqlParameter("@Status", MySqlDbType.Int32,11),
					new MySqlParameter("@DeptId", MySqlDbType.VarChar,50),
					new MySqlParameter("@Gender", MySqlDbType.Bit,4),
					new MySqlParameter("@Signature", MySqlDbType.VarChar,50),
					new MySqlParameter("@HeadPic", MySqlDbType.Int32,11),
					new MySqlParameter("@CellPhone", MySqlDbType.VarChar,11),
					new MySqlParameter("@OfficePhone", MySqlDbType.VarChar,16),
					new MySqlParameter("@Email", MySqlDbType.VarChar,50),
					new MySqlParameter("@Position", MySqlDbType.VarChar,50),
					new MySqlParameter("@DisplayIndex", MySqlDbType.Int32,11),
					new MySqlParameter("@Comment", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.EnglishName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.DeptId;
            parameters[6].Value = model.Gender;
            parameters[7].Value = model.Signature;
            parameters[8].Value = model.HeadPic;
            parameters[9].Value = model.CellPhone;
            parameters[10].Value = model.OfficePhone;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.Position;
            parameters[13].Value = model.DisplayIndex;
            parameters[14].Value = model.Comment;

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
        public bool Update(AndroidMvcServer.Model.Tb_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("EnglishName=@EnglishName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Status=@Status,");
            strSql.Append("DeptId=@DeptId,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("Signature=@Signature,");
            strSql.Append("HeadPic=@HeadPic,");
            strSql.Append("CellPhone=@CellPhone,");
            strSql.Append("OfficePhone=@OfficePhone,");
            strSql.Append("Email=@Email,");
            strSql.Append("Position=@Position,");
            strSql.Append("DisplayIndex=@DisplayIndex,");
            strSql.Append("Comment=@Comment");
            strSql.Append(" where UserId=@UserId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserName", MySqlDbType.VarChar,10),
					new MySqlParameter("@EnglishName", MySqlDbType.VarChar,15),
					new MySqlParameter("@Pwd", MySqlDbType.VarChar,32),
					new MySqlParameter("@Status", MySqlDbType.Int32,11),
					new MySqlParameter("@DeptId", MySqlDbType.VarChar,50),
					new MySqlParameter("@Gender", MySqlDbType.Bit,4),
					new MySqlParameter("@Signature", MySqlDbType.VarChar,50),
					new MySqlParameter("@HeadPic", MySqlDbType.Int32,11),
					new MySqlParameter("@CellPhone", MySqlDbType.VarChar,11),
					new MySqlParameter("@OfficePhone", MySqlDbType.VarChar,16),
					new MySqlParameter("@Email", MySqlDbType.VarChar,50),
					new MySqlParameter("@Position", MySqlDbType.VarChar,50),
					new MySqlParameter("@DisplayIndex", MySqlDbType.Int32,11),
					new MySqlParameter("@Comment", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserId", MySqlDbType.VarChar,15)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.EnglishName;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.DeptId;
            parameters[5].Value = model.Gender;
            parameters[6].Value = model.Signature;
            parameters[7].Value = model.HeadPic;
            parameters[8].Value = model.CellPhone;
            parameters[9].Value = model.OfficePhone;
            parameters[10].Value = model.Email;
            parameters[11].Value = model.Position;
            parameters[12].Value = model.DisplayIndex;
            parameters[13].Value = model.Comment;
            parameters[14].Value = model.UserId;

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
        public bool Delete(string UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_user ");
            strSql.Append(" where UserId=@UserId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserId", MySqlDbType.VarChar,15)			};
            parameters[0].Value = UserId;

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
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_user ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
        public AndroidMvcServer.Model.Tb_User GetModel(string UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,UserName,EnglishName,Pwd,Status,DeptId,Gender,Signature,HeadPic,CellPhone,OfficePhone,Email,Position,DisplayIndex,Comment from tb_user ");
            strSql.Append(" where UserId=@UserId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserId", MySqlDbType.VarChar,15)			};
            parameters[0].Value = UserId;

            AndroidMvcServer.Model.Tb_User model = new AndroidMvcServer.Model.Tb_User();
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
        public AndroidMvcServer.Model.Tb_User DataRowToModel(DataRow row)
        {
            AndroidMvcServer.Model.Tb_User model = new AndroidMvcServer.Model.Tb_User();
            if (row != null)
            {
                if (row["UserId"] != null)
                {
                    model.UserId = row["UserId"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["EnglishName"] != null)
                {
                    model.EnglishName = row["EnglishName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["DeptId"] != null)
                {
                    model.DeptId = row["DeptId"].ToString();
                }
                if (row["Gender"] != null && row["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(row["Gender"].ToString());
                }
                if (row["Signature"] != null)
                {
                    model.Signature = row["Signature"].ToString();
                }
                if (row["HeadPic"] != null && row["HeadPic"].ToString() != "")
                {
                    model.HeadPic = int.Parse(row["HeadPic"].ToString());
                }
                if (row["CellPhone"] != null)
                {
                    model.CellPhone = row["CellPhone"].ToString();
                }
                if (row["OfficePhone"] != null)
                {
                    model.OfficePhone = row["OfficePhone"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Position"] != null)
                {
                    model.Position = row["Position"].ToString();
                }
                if (row["DisplayIndex"] != null && row["DisplayIndex"].ToString() != "")
                {
                    model.DisplayIndex = int.Parse(row["DisplayIndex"].ToString());
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
            strSql.Append("select UserId,UserName,EnglishName,Pwd,Status,DeptId,Gender,Signature,HeadPic,CellPhone,OfficePhone,Email,Position,DisplayIndex,Comment ");
            strSql.Append(" FROM tb_user ");
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
            strSql.Append("select count(1) FROM tb_user ");
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
                strSql.Append("order by T.UserId desc");
            }
            strSql.Append(")AS Row, T.*  from tb_user T ");
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
            parameters[0].Value = "tb_user";
            parameters[1].Value = "UserId";
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


        public Tb_User GetModelByDepId(string DepId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据部门ID获取部门所有人
        /// </summary>
        /// <param name="DepId"></param>
        /// <returns></returns>
        public List<Tb_User> GetUsersByDepId(string depId)
        {
            string strSql = "SELECT tb_user.*,tb_dept.ParDepId FROM tb_user,tb_dept WHERE tb_user.DeptId=tb_dept.DepId&&tb_user.DeptId='" + depId + "'";
            MySqlDataReader reader = DbHelperMySQL.ExecuteReader(strSql);
            while (reader.Read())
            {
                string DepId = reader["DepId"].ToString();
                string ParDepId = reader["ParDepId"].ToString();
                while (ParDepId != "JURASSIC")
                {
                    string sql1 = "SELECT tb_user.*,tb_dept.ParDepId FROM tb_user,tb_dept WHERE tb_user.DeptId=tb_dept.DepId&&tb_user.DeptId='" + ParDepId + "'";
                    MySqlDataReader sdr1 = DbHelperMySQL.ExecuteReader(sql1);
                    while (sdr1.Read())
                    {
                        string DepId1 = reader["DepId"].ToString();
                        ParDepId = reader["ParDepId"].ToString();
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}