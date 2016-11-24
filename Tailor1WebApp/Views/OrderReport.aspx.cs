using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Globalization;

namespace Tailor1WebApp.Report
{
    public partial class OrderReport : System.Web.UI.Page
    {
        //private SqlConnection connection;     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {            
            //DateTime formDates = DateTime.ParseExact(txtFromDate.Text,"dd-MM-yyyy",CultureInfo.InvariantCulture);
            //string formDatevalue = formDates.ToString("dd-MM-yyyy");
            ShowReport();
        }
        private void ShowReport()
        {
            //reset

            rptViewer.Reset();

            //datasource
            //DataTable dt = GetData(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
            DataTable dt = GetData(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
            ReportDataSource rdataSource = new ReportDataSource("DataSet1", dt);

            rptViewer.LocalReport.DataSources.Add(rdataSource);


            //path
            //rptViewer.LocalReport.ReportPath = "OrderReport.rdlc";
            //rptViewer.LocalReport.ReportPath = "OrderReport1.rdlc";
            rptViewer.LocalReport.ReportPath = "Report/OrderReport1.rdlc";
            

            //parameter

            ReportParameter[] rptParam = new ReportParameter[]
            {
                
                new ReportParameter("fromDate",txtFromDate.Text),
                new ReportParameter("toDate",txtToDate.Text)
            };

            rptViewer.LocalReport.SetParameters(rptParam);
            //refresh

            rptViewer.LocalReport.Refresh();



        }
        private DataTable GetData(DateTime fromDate,DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            //connection = new SqlConnection();
            //string conn = ConfigurationManager.ConnectionStrings["TailorTest"].ConnectionString;
            string conn = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            //connection.ConnectionString = conn;
            using(SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("GetAllUndeliveredOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@From", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@To", SqlDbType.DateTime).Value = toDate;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
    }
}