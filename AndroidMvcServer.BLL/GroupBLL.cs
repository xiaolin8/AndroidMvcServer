using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AndroidMvcServer.DAL;

namespace AndroidMvcServer.BLL
{
    public class GroupBLL
    {
        MySqlHelper.SqlHelper sqlHelper = new MySqlHelper.SqlHelper();

        public DataTable getGroupsByDepId(string DepId)
        {
            string strSqlStr;
            List<string> groupList = new List<string>();
            if (!string.IsNullOrEmpty(DepId))
            {
                strSqlStr = "SELECT * FROM Tb_Group";
                DataSet dataSet = this.sqlHelper.GetDataSet(strSqlStr);
                if (dataSet != null)
                {
                    if (dataSet.Tables[0] != null)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            DataRowView rowview = dataSet.Tables[0].DefaultView[i];
                            string groupId = rowview["groupId"].ToString();
                            string groupName = rowview["groupName"].ToString();
                            string groupOwner = rowview["groupOwner"].ToString();
                            string groupDesc = rowview["groupDesc"].ToString();
                            string isPublic = rowview["isPublic"].ToString();
                            string allowInvite = rowview["allowInvite"].ToString();
                            string memberNum = rowview["memberNum"].ToString();
                            string maxUsers = rowview["maxUsers"].ToString();
                            groupList.Add(DepId);
                        }
                    }
                }
                if (groupList.Count > 0)
                {
                }
                StringBuilder builder = new StringBuilder();
                //获取群主的部门所在地
                string subCompany;
                return null;
            }
            return null;
        }
    }
}
