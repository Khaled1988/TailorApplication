using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tailor1WebApp.Models
{
    public class CustomerMeasurement
    {
        public int CustomerMeasurementID { get; set; }
        public int MeasurementID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerIDCard { get; set; }
        public string CustomerMobile { get; set; }
        public int DressTypeID { get; set; }
        public string DressTypeName { get; set; }
        public double Length { get; set; }
        public double Chest { get; set; }
        public double WaistBelly { get; set; }
        public double Hip { get; set; }
        public double Shoulder { get; set; }
        public double SleeveLength { get; set; }
        public double CuffOpening { get; set; }
        public double Neck { get; set; }
        public double AllRoundRise { get; set; }
        public double Thaigh { get; set; }
        public double BottomOpening { get; set; }
        //public DateTime MeasurementDate { get; set; }
    }
}