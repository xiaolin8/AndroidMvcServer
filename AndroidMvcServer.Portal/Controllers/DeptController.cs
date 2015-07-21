using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AndroidMvcServer.BLL;
using AndroidMvcServer.Portal.Models;

namespace AndroidMvcServer.Portal.Controllers
{
    public class DeptController : Controller
    {
        private string DepId;
        private string DepName;
        private string ParDepId;
        private int DisplayIndex;
        private string DirectorId;
        private string DirectorName;
        private string DepEmail;
        private int Status;
        private string Comment;
        private bool IsLeaf;//当前是否是叶子节点
        private DataTable DTable;

        DeptBLL bll = new DeptBLL();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Dept/
        [AcceptVerbs(HttpVerbs.Get)]
        public string GetDeptListJson()
        {
            GetDepDataByDepId("JURASSIC");
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Concat(new object[] { "{'DepId':'", DepId, "','DepName':'", DepName, "','icon':'../../Content/Themes/Images/16/house.png','DirectorName':'", DirectorName, "','DepEmail':'", DepEmail, "','Status':'", Status, "','leaf':'", IsLeaf.ToString().ToLower(), "','Comment':'", Comment, "','children': [" }));
            List<string> depListByParDepId = GetDepListByParDepId(DepId);
            for (int i = 0; i < depListByParDepId.Count; i++)
            {
                string id = depListByParDepId[i];
                GetDepDataByDepId(id);
                builder.Append(string.Concat(new object[] { "{'DepId':'", DepId, "','DepName':'", DepName, "','icon':'../../Content/Themes/Images/16/chart_organisation.png','DirectorName':'", DirectorName, "','DepEmail':'", DepEmail, "','Status':'", Status, "','leaf':'", IsLeaf.ToString().ToLower(), "','Comment':'", Comment, "'" }));
                if (!IsLeaf)
                {
                    builder.Append(",'children': [");
                    List<string> list2 = GetDepListByParDepId(DepId);
                    for (int j = 0; j < list2.Count; j++)
                    {
                        string str2 = list2[j];
                        GetDepDataByDepId(str2);
                        builder.Append(string.Concat(new object[] { "{'DepId':'", DepId, "','DepName':'", DepName, "','icon':'../../Content/Themes/Images/16/wand.png','DirectorName':'", DirectorName, "','DepEmail':'", DepEmail, "','Status':'", Status, "','leaf':'", IsLeaf.ToString().ToLower(), "','Comment':'", Comment, "'" }));
                        if (!IsLeaf)
                        {
                            builder.Append(",'children': [");
                            List<string> list3 = GetDepListByParDepId(DepId);
                            for (int k = 0; k < list3.Count; k++)
                            {
                                string str3 = list3[k];
                                GetDepDataByDepId(str3);
                                builder.Append(string.Concat(new object[] { "{'DepId':'", DepId, "','DepName':'", DepName, "','icon':'../../Content/Themes/Images/16/users.png','DirectorName':'", DirectorName, "','DepEmail':'", DepEmail, "','Status':'", Status, "','leaf':'", IsLeaf.ToString().ToLower(), "','Comment':'", Comment, "'" }));
                                if (!IsLeaf)
                                {
                                    builder.Append(",'children': [");
                                    List<string> list4 = GetDepListByParDepId(DepId);
                                    for (int m = 0; m < list4.Count; m++)
                                    {
                                        string str4 = list4[m];
                                        GetDepDataByDepId(str4);
                                        builder.Append(string.Concat(new object[] { "{'DepId':'", DepId, "','DepName':'", DepName, "','icon':'../../Content/Themes/Images/16/asterisk_orange.png','DirectorName':'", DirectorName, "','DepEmail':'", DepEmail, "','Status':'", Status, "','leaf':'", IsLeaf.ToString().ToLower(), "','Comment':'", Comment, "'" }));
                                        if (!IsLeaf)
                                        {
                                            builder.Append("',children': [");
                                            List<string> list5 = GetDepListByParDepId(DepId);
                                            for (int n = 0; n < list5.Count; n++)
                                            {
                                                string str5 = list4[n];
                                                GetDepDataByDepId(str5);
                                                builder.Append(string.Concat(new object[] { "{'DepId':'", DepId, "','DepName':'", DepName, "','icon':'../../Content/Themes/Images/16/asterisk_orange.png','DirectorName':'", DirectorName, "','DepEmail':'", DepEmail, "','Status':'", Status, "','leaf':'", IsLeaf.ToString().ToLower(), "','Comment':'", Comment, "'}," }));
                                            }
                                            builder.Remove(builder.Length - 1, 1);
                                        }
                                        else
                                        {
                                            builder.Append("},");
                                            if (m == (list4.Count - 1))
                                            {
                                                builder.Remove(builder.Length - 1, 1);
                                            }
                                        }
                                    }
                                    builder.Append("]},");
                                }
                                else
                                {
                                    builder.Append("},");
                                    if (k == (list3.Count - 1))
                                    {
                                        builder.Remove(builder.Length - 1, 1);
                                    }
                                }
                            }
                            builder.Append("]},");
                        }
                        else
                        {
                            builder.Append("},");
                            if (j == (list2.Count - 1))
                            {
                                builder.Remove(builder.Length - 1, 1);
                            }
                        }
                    }
                    builder.Append("]},");
                }
                else
                {
                    builder.Append("},");
                    if (i == (depListByParDepId.Count - 1))
                    {
                        builder.Remove(builder.Length - 1, 1);
                    }
                }
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]}");
            return builder.ToString();
        }

        /// <summary>根据DepId返回部门详细信息
        /// </summary>
        public void GetDepDataByDepId(string id)
        {
            DTable = bll.getDeptDetailByDepId(id);
            if (DTable != null)
            {
                for (int i = 0; i < DTable.Rows.Count; i++)
                {
                    DataRowView view = DTable.DefaultView[i];
                    DepId = view["DepId"].ToString();
                    DepName = view["DepName"].ToString();
                    ParDepId = view["ParDepId"].ToString();
                    DisplayIndex = Convert.ToInt32(view["DisplayIndex"].ToString());
                    DirectorId = view["DirectorId"].ToString();
                    if ((DirectorId != null) && (DirectorId != ""))
                    {
                        DirectorName = getNickById(DirectorId);
                    }
                    DepEmail = view["DepEmail"].ToString();
                    Status = Convert.ToInt32(view["Status"].ToString());
                    Comment = view["Comment"].ToString();
                    string t = view["IsLeaf"].ToString();
                    IsLeaf = t == "1" ? true : false;
                }
            }
        }

        /// <summary>根据ParDepId返回部门ID列表
        /// </summary>
        public List<string> GetDepListByParDepId(string ParDepId)
        {
            return bll.getDeptsByParDepId(ParDepId);//一级节点
        }

        public string getNickById(string userName)
        {
            return AndroidMvcServer.DAL.MySqlHelper.getFirstRow("SELECT UserName FROM Tb_User WHERE UserId = '" + userName + "'");
        }


    }
}