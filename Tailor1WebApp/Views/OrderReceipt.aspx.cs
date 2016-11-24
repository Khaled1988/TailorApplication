using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tailor1WebApp.Views
{
    public partial class OrderReceipt : System.Web.UI.Page
    {
        string testid;
        int MeasurementID = 0;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderID = (Request["Name"]);
                string measurementID = (Request["meID"]);
                var fromDate = Request.QueryString["fromDate"];
                var toDate = Request.QueryString["toDate"];
                if (orderID != null)
                {
                    testid = orderID;
                    divCustomerMeasurement.Visible = false;
                    ShowReport();
                }
                else if (measurementID != "" && measurementID != null )
                {
                    MeasurementID = Convert.ToInt32(measurementID);
                    divOrderReceipt.Visible = false;
                    ShowMeasurementReport();
                }                
                else
                {

                }
            }
        }
        
        private void ShowReport()
        {
            //reset
            rptViewer.Reset();

            //datasource            
            DataTable dt = GetData(testid);   
            ReportDataSource rdataSource = new ReportDataSource("ReceiptDataset", dt);
            rptViewer.LocalReport.DataSources.Add(rdataSource);

            //path            
            rptViewer.LocalReport.ReportPath = "Report/OrderReceipt.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("OrderNo", testid) 
            };
            rptViewer.LocalReport.SetParameters(rptParam);

            //refresh
            rptViewer.LocalReport.Refresh();

        }
        private DataTable GetData(string OrderNo)
        {
            string constr = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetOrderReceipt"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("@OrderNO", testid);
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }
        private void ShowMeasurementReport()
        {
            //reset
            rptViewerMeasurement.Reset();

            //datasource            
            DataTable dt = GetMeasurementData(MeasurementID);
            ReportDataSource rdataSource = new ReportDataSource("MeasurementDataSet", dt);
            rptViewerMeasurement.LocalReport.DataSources.Add(rdataSource);

            //path            
            rptViewerMeasurement.LocalReport.ReportPath = "Report/CustomerMeasurement.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("MeasurementID", MeasurementID.ToString()) 
            };
            rptViewerMeasurement.LocalReport.SetParameters(rptParam);

            //refresh
            rptViewerMeasurement.LocalReport.Refresh();

        }
        private DataTable GetMeasurementData(Int32 MeasurementID)
        {
            string constr = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            DataTable mdt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomerMeasurement"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("@MeasurementID", MeasurementID);
                        sda.Fill(mdt);
                    }
                }
            }
            return mdt;
        }
    }
}