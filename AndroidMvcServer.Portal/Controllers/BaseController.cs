using System.Web.Mvc;
using AndroidMvcServer.Model;

namespace AndroidMvcServer.Portal.Controllers
{
    /// <summary>
    /// 基类BaseController，过滤器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前登录的用户属性
        /// </summary>、、
        public Tb_User CurrentUserInfo { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //得到用户登录的信息
            CurrentUserInfo = Session["UserInfo"] as Tb_User;
            //判断用户是否为空
            if (CurrentUserInfo == null)
            {
                Response.Redirect("/Home/Index");
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // 标记异常已处理
            filterContext.ExceptionHandled = true;
            // 跳转到错误页
            filterContext.Result = new RedirectResult(Url.Action("Error", "Shared"));
        }
    }
}
