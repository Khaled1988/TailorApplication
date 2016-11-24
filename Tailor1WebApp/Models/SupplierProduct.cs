using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class SupplierProduct
    {
        public int SupplierProductID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierMobile { get; set; }
        public string MaterialName { get; set; }
        public double MaterialPrice { get; set; }
        public double MaterialQuantity { get; set; }
        public string MaterialUnit { get; set; }
        public string MaterialCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string OtherInformation { get; set; }
        public int MaterialID { get; set; }
    }
}