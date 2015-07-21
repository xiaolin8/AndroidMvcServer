using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AndroidMvcServer.DAL;
using MySql.Data.MySqlClient;

namespace AndroidMvcServer.BLL
{
    public class UserBLL
    {
        AndroidMvcServer.DAL.MySqlHelper.SqlHelper sqlHelper = new AndroidMvcServer.DAL.MySqlHelper.SqlHelper();

        public DataTable getUserTable()
        {
            string strSqlStr = "SELECT * FROM Tb_User";
            DataSet DSet = sqlHelper.GetDataSet(strSqlStr);
            if (DSet != null)
            {
                return DSet.Tables[0];
            }
            return null;
        }

        public DataTable getUsersByDepId(string DepId)
        {
            MySqlParameter[] sp = new MySqlParameter[] { new MySqlParameter("@DepId", DepId), new MySqlParameter("@dept", MySqlDbType.VarChar, 500) };
            sp[1].Direction = ParameterDirection.Output;
            string str = this.sqlHelper.OutPutProc("pro_GetAllChildrenDeptIdByDeptId", sp);
            string strSqlStr;
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Split(new char[] { '\\' });
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < strArray.Length; i++)
                {
                    builder.Append(" OR ParDepId = '" + strArray[i] + "' ");
                }
                strSqlStr = "SELECT UserId,UserName, EnglishName, Tb_User. Status, Tb_User . DeptId , Gender , Signature , HeadPic , CellPhone , OfficePhone , Email , Position , Tb_User . DisplayIndex , Tb_User . Comment  FROM  Tb_User , Tb_Dept  WHERE  Tb_Dept . DepId  =  Tb_User . DeptId  AND ( ParDepId ='" + DepId + "'" + builder.ToString() + ")";
            }
            else
            {
                strSqlStr = "SELECT  UserId , UserName , EnglishName , Tb_User . Status , Tb_User . DeptId , Gender , Signature , HeadPic , CellPhone , OfficePhone , Email , Position , Tb_User . DisplayIndex , Tb_User . Comment  FROM  Tb_User , Tb_Dept  WHERE  Tb_Dept . DepId  =  Tb_User . DeptId  AND ( DeptId ='" + DepId + "' OR ParDepId = '" + DepId + "')";
            }
            DataSet dataSet = this.sqlHelper.GetDataSet(strSqlStr);
            if (dataSet != null)
            {
                return dataSet.Tables[0];
            }
            return null;
        }

        public DataTable getUsersByUserIds(List<string> userIdList)
        {
            StringBuilder sbSql = new StringBuilder("SELECT * FROM Tb_User WHERE UserId = '" + userIdList[0] + "'");
            for (int i = 0; i < userIdList.Count; i++)
            {
                sbSql.Append(" OR UserId = '" + userIdList[i] + "'");
            }
            DataSet DSet = sqlHelper.GetDataSet(sbSql.ToString());
            if (DSet != null)
            {
                return DSet.Tables[0];
            }
            return null;
        }
    }
}
