using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class OrderMaterial
    {
        public int OrderMaterialID { get; set; }
        public int OrderID { get; set; }
        public string MaterialCode { get; set; }
        public double MaterialQuantity { get; set; }
        public string MaterialUnit { get; set; }
        public DateTime OrderMaterialDate { get; set; }
        public string OrderNo { get; set; }
    }
}