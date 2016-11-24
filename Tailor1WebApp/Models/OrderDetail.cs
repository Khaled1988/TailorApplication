using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int DressTypeID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    
    }
}