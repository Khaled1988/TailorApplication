using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double PaidAmount { get; set; }
        public double Discount { get; set; }
        public int PaymentStatus { get; set; }
        public double DueAmount { get; set; }
        public int DeliveryStatus { get; set; }
        public int CancilStatus { get; set; }
        public string Remarks { get; set; }
        
    }
}