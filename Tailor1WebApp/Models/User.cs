using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
    }
}