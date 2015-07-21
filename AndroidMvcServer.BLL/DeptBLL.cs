using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AndroidMvcServer.DAL;

namespace AndroidMvcServer.BLL
{
    public class DeptBLL
    {
        MySqlHelper.SqlHelper sqlHelper = new MySqlHelper.SqlHelper();

        public DataTable getDeptTable()
        {
            string strSqlStr = "SELECT * FROM Tb_Dept";
            DataSet DSet = sqlHelper.GetDataSet(strSqlStr);
            if (DSet != null)
            {
                return DSet.Tables[0];
            }
            return null;
        }

        /// <summary>根据ParDepId获取子部门ID列表
        /// </summary>
        public List<string> getDeptsByParDepId(string ParDepId)
        {
            string strSqlStr = "SELECT DepId FROM Tb_Dept WHERE ParDepId='" + ParDepId + "'";
            List<string> depList = new List<string>();
            DataSet DSet = sqlHelper.GetDataSet(strSqlStr);
            if (DSet != null)
            {
                if (DSet.Tables[0] != null)
                {
                    for (int i = 0; i < DSet.Tables[0].Rows.Count; i++)
                    {
                        DataRowView rowview = DSet.Tables[0].DefaultView[i];
                        string DepId = rowview["DepId"].ToString();
                        depList.Add(DepId);
                    }
                }
                return depList;
            }
            return null;
        }

        /// <summary>根据DepId获取部门详细信息
        /// </summary>
        public DataTable getDeptDetailByDepId(string DepId)
        {
            string strSqlStr = "SELECT * FROM Tb_Dept WHERE DepId='" + DepId + "'";
            DataSet DSet = sqlHelper.GetDataSet(strSqlStr);
            if (DSet != null)
            {
                return DSet.Tables[0];
            }
            return null;
        }
    }
}
