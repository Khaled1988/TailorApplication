using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class DressMeasurement
    {
        public int DressMeasurementID { get; set; }
        public int CustomerID { get; set; }
        public int DressTypeID { get; set; }
        public string CustomerIDNo { get; set; }
        public string CustomerName { get; set; }
        public string DressType { get; set; }
        public double DressPrice { get; set; }
        public int Quantity { get; set; }
    }
}