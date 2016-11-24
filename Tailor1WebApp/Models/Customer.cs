using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }        
        public string CustomerIDNo { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public string CustomerType { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public string WorkStation { get; set; }
    }
}