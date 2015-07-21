using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AndroidMvcServer.BLL;
using AndroidMvcServer.DAL;
using AndroidMvcServer.Portal.Models;
using MySql.Data.MySqlClient;

namespace AndroidMvcServer.Controllers
{
    public class UserController : Controller
    {
        private AndroidMvcServer.DAL.MySqlHelper.SqlHelper sqlHelper = new AndroidMvcServer.DAL.MySqlHelper.SqlHelper();
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetUsers()
        {
            //加载组织机构列表
            UserBLL bll = new UserBLL();
            DataTable DTable = bll.getUserTable();
            if (DTable != null)
            {
                List<UserModel> litestModel = new List<UserModel>();
                for (int i = 0; i < DTable.Rows.Count; i++)
                {
                    DataRowView rowview = DTable.DefaultView[i];
                    litestModel.Add(new UserModel()
                    {
                        UserName = rowview["UserName"].ToString(),
                        UserId = rowview["UserId"].ToString(),
                        EnglishName = rowview["EnglishName"].ToString(),
                        Signature = rowview["Signature"].ToString(),
                        Status = Convert.ToInt32(rowview["Status"].ToString()),
                        Gender = Convert.ToBoolean(rowview["Gender"].ToString()),
                        CellPhone = rowview["CellPhone"].ToString(),
                        OfficePhone = rowview["OfficePhone"].ToString(),
                        Email = rowview["Email"].ToString(),
                        DeptId = rowview["DeptId"].ToString(),
                        Position = rowview["Position"].ToString(),
                        HeadPic = Convert.ToInt32(rowview["HeadPic"].ToString()),
                        DisplayIndex = Convert.ToInt32(rowview["DisplayIndex"].ToString()),
                        Comment = rowview["Comment"].ToString()
                    });
                }
                return Json(litestModel, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetUsersByDepId(string DepId)
        {
            UserBLL bll = new UserBLL();
            DataTable DTable = bll.getUsersByDepId(DepId);
            if (DTable != null)
            {
                List<UserModel> litestModel = new List<UserModel>();
                for (int i = 0; i < DTable.Rows.Count; i++)
                {
                    DataRowView rowview = DTable.DefaultView[i];
                    litestModel.Add(new UserModel()
                    {
                        UserName = rowview["UserName"].ToString(),
                        EnglishName = rowview["EnglishName"].ToString(),
                        UserId = rowview["UserId"].ToString(),
                        Status = Convert.ToInt32(rowview["Status"].ToString()),
                        Gender = Convert.ToBoolean(rowview["Gender"].ToString()),
                        Signature = rowview["Signature"].ToString(),
                        HeadPic = Convert.ToInt32(rowview["HeadPic"].ToString()),
                        CellPhone = rowview["CellPhone"].ToString(),
                        OfficePhone = rowview["OfficePhone"].ToString(),
                        Email = rowview["Email"].ToString(),
                        DeptId = rowview["DeptId"].ToString(),
                        Position = rowview["Position"].ToString(),
                        DisplayIndex = Convert.ToInt32(rowview["DisplayIndex"].ToString()),
                        active = true,
                        Comment = rowview["Comment"].ToString()
                    });
                }
                return Json(litestModel, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public string GetDept(string UserId)
        {
            MySqlParameter[] sp = new MySqlParameter[8];
            sp[0] = new MySqlParameter("@userId", UserId);
            sp[1] = new MySqlParameter("@dept1", MySqlDbType.VarChar, 50);
            sp[1].Direction = ParameterDirection.Output;
            sp[2] = new MySqlParameter("@dept2", MySqlDbType.VarChar, 50);
            sp[2].Direction = ParameterDirection.Output;
            sp[3] = new MySqlParameter("@dept3", MySqlDbType.VarChar, 50);
            sp[3].Direction = ParameterDirection.Output;
            sp[4] = new MySqlParameter("@dept4", MySqlDbType.VarChar, 50);
            sp[4].Direction = ParameterDirection.Output;
            sp[5] = new MySqlParameter("@DepId", MySqlDbType.VarChar, 50);
            sp[5].Direction = ParameterDirection.Output;
            sp[6] = new MySqlParameter("@DepName", MySqlDbType.VarChar, 50);
            sp[6].Direction = ParameterDirection.Output;
            sp[7] = new MySqlParameter("@ParDepId", MySqlDbType.VarChar, 50);
            sp[7].Direction = ParameterDirection.Output;
            return this.sqlHelper.OutPutProcToSp("pro_GetFullDeptsByUserId", sp);
        }

        /// <summary>
        /// 获取用户在云服务器上的详细信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string Details(string userName)
        {//除了一个"username" : "huxl"
            HXService hxService = new HXService();
            return hxService.AccountGet("huxl");
        }

        /// <summary>
        /// 获取云服务器上的消息记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string getChatMessages(string userName)
        {//除了一个"username" : "huxl"
            HXService hxService = new HXService();
            return hxService.getChatMessages("huxl");
        }

        public string getNickById(string userName)
        {
            string strSql = "SELECT UserName FROM Tb_User WHERE UserId = '" + userName + "'";
            return AndroidMvcServer.DAL.MySqlHelper.getFirstRow(strSql);
        }

        public int GetPerPhoto(string UserId)
        {
            return Convert.ToInt32(AndroidMvcServer.DAL.MySqlHelper.getFirstRow("SELECT HeadPic FROM Tb_User WHERE UserId = '" + UserId + "'"));
        }

        //
        // GET: /User/
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
