using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class CustomerDressOrder
    {
        public int CustomerDressOrderID { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public string DressType { get; set; }
        public int DressQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Designation { get; set; }

    }
}