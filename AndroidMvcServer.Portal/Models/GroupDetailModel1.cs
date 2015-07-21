using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AndroidMvcServer.Portal.Models;

namespace AndroidMvcServer.Portal.Controllers
{
    [Serializable()]
    public class GroupDetailModel1
    {
        [Display(Name = "群成员")]
        public GroupDetailModel2[] data { get; set; }
    }
}