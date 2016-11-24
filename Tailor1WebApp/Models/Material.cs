using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class Material
    {
        public int MaterialID { get; set; }
        public int SupplierID { get; set; }
        public string MaterialName { get; set; }
        public double MaterialPrice { get; set; }
        public double MaterialQuantity { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialOtherInfo { get; set; }
        public string Unit { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}