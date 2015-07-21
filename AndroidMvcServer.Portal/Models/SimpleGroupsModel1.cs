using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AndroidMvcServer.Portal.Models;

namespace AndroidMvcServer.Portal.Models
{
    [Serializable()]
    public class SimpleGroupsModel1
    {
        [Display(Name = "群成员")]
        public SimpleGroupsModel2[] data { get; set; }

        [Display(Name = "群总数")]
        public int count { get; set; }
    }
}