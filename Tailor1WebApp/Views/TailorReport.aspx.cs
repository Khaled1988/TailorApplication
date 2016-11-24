using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tailor1WebApp.BLL;

namespace Tailor1WebApp.Views
{
    public partial class TailorReport : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divOrderReport.Visible = false;
                divCustomerWiseDelivery.Visible = false;
                divMaterialStatus.Visible = false;
                divMaterialStatusDatewise.Visible = false;
            }
        }

        protected void btnShowOrderReport_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtFromDate.Text)) && (!string.IsNullOrEmpty(txtToDate.Text)))
            {
                ShowOrderReport();
            }
            else
            {
                lblmessage.Text = "Enter Date Correctly";
            }
        }
        private void ShowOrderReport()
        {
            //reset
            divOrderReport.Visible = true;
            ReportViewerOrderReport.Reset();

            //datasource 


            String[] fromdate = txtFromDate.Text.Split(new char[] { '/' });
            DateTime FromDate = new DateTime(int.Parse(fromdate[0]), int.Parse(fromdate[1]), int.Parse(fromdate[2]));

            String[] todate = txtToDate.Text.Split(new char[] { '/' });
            DateTime ToDate = new DateTime(int.Parse(todate[0]), int.Parse(todate[1]), int.Parse(todate[2]));


            //DataTable dt = GetOrderReportData(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
            DataTable dt = GetOrderReportData(FromDate, ToDate);
            ReportDataSource rdataSource = new ReportDataSource("DataSet1", dt);
            ReportViewerOrderReport.LocalReport.DataSources.Add(rdataSource);

            //path            
            ReportViewerOrderReport.LocalReport.ReportPath = "Report/OrderReport1.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("fromDate",txtFromDate.Text),
                new ReportParameter("toDate",txtToDate.Text)
            };
            ReportViewerOrderReport.LocalReport.SetParameters(rptParam);

            //refresh
            ReportViewerOrderReport.LocalReport.Refresh();
            btnORhidden.Focus();

        }
        private DataTable GetOrderReportData(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
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


        protected void btnCustomerWiseDeliveryRpt_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim() != "")
            {
                ShowCustomerWiseDeliveryReport();
            }
            else
            {
                lblCustomerMsg.Text = "Please enter Customer ID";
            }
        }
        private void ShowCustomerWiseDeliveryReport()
        {
            //reset
            divCustomerWiseDelivery.Visible = true;
            ReportViewerCustomerWiseDelivery.Reset();

            //datasource            
            DataTable dt = GetCustomerWiseDeliveryData(txtCustomerID.Text.Trim());
            ReportDataSource rdataSource = new ReportDataSource("OrderDataset", dt);
            ReportViewerCustomerWiseDelivery.LocalReport.DataSources.Add(rdataSource);

            //path            
            ReportViewerCustomerWiseDelivery.LocalReport.ReportPath = "Report/CustomerWiseOrderReport.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("CustomerID",txtCustomerID.Text.Trim())
            };
            ReportViewerCustomerWiseDelivery.LocalReport.SetParameters(rptParam);

            //refresh
            ReportViewerCustomerWiseDelivery.LocalReport.Refresh();
            btnCWDHidden.Focus();
        }
        private DataTable GetCustomerWiseDeliveryData(string CustomerID)
        {
            string constr = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomerWiseOrderReceipt"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text.Trim());
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }




        protected void btnShowMaterialStatus_Click(object sender, EventArgs e)
        {
            if (txtMaterialCode.Text.Trim() != "")
            {
                ShowSingleMaterialReport();
            }
            //else if (txtMaterialCode.Text.Trim() == "")
            //{
            //    ShowAllMaterialReport();
            //}
            else
            {
                lblMaterialStatusMsg.Text = "Please enter MaterialCode";
            }
        }
        private void ShowSingleMaterialReport()
        {
            //reset
            divMaterialStatus.Visible = true;
            MaterialStatusReportViewer.Reset();

            //datasource            
            DataTable dt = GetMaterialStatusData(txtMaterialCode.Text.Trim());
            ReportDataSource rdataSource = new ReportDataSource("MaterialDataSet", dt);
            MaterialStatusReportViewer.LocalReport.DataSources.Add(rdataSource);

            //path            
            MaterialStatusReportViewer.LocalReport.ReportPath = "Report/SingleMaterialStatusReport.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("MaterialCode",txtMaterialCode.Text.Trim())
            };
            MaterialStatusReportViewer.LocalReport.SetParameters(rptParam);

            //refresh
            MaterialStatusReportViewer.LocalReport.Refresh();
            btnMShidden.Focus();
        }
        private DataTable GetMaterialStatusData(string materialCode)
        {
            string constr = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                if (materialCode == "")
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllMaterialStatus"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("GetSingleMaterialStatus"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Parameters.AddWithValue("@MaterialCode", materialCode);
                            sda.Fill(dt);
                        }
                    }
                }

            }
            return dt;
        }
        private void ShowAllMaterialReport()
        {
            //reset
            divMaterialStatus.Visible = true;
            MaterialStatusReportViewer.Reset();

            //datasource            
            DataTable dt = GetMaterialStatusData("");
            ReportDataSource rdataSource = new ReportDataSource("MaterialDataset", dt);
            MaterialStatusReportViewer.LocalReport.DataSources.Add(rdataSource);

            //path            
            MaterialStatusReportViewer.LocalReport.ReportPath = "Report/AllMaterialStatusReport.rdlc";

            //parameter            
            //MaterialStatusReportViewer.LocalReport.SetParameters(rptParam);

            //refresh
            MaterialStatusReportViewer.LocalReport.Refresh();
            btnMShidden.Focus();
        }


        protected void btnShowReportASD_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtFromDateASD.Text)) && (!string.IsNullOrEmpty(txtToDateASD.Text)))
            {
                if (rbInQuantity.Checked)
                {
                    ShowMaterialInStatusReport();
                }
                else
                {
                    ShowMaterialOutStatusReport();
                }

            }
            else
            {
                lblmessageASD.Text = "Enter Date Correctly";
            }
        }
        private void ShowMaterialInStatusReport()
        {
            //reset
            divMaterialStatusDatewise.Visible = true;
            ReportViewerASD.Reset();

            //datasource            

            String[] fromdate = txtFromDateASD.Text.Split(new char[] { '/' });
            DateTime FromDateASD = new DateTime(int.Parse(fromdate[0]), int.Parse(fromdate[1]), int.Parse(fromdate[2]));

            String[] todate = txtToDateASD.Text.Split(new char[] { '/' });
            DateTime ToDateASD = new DateTime(int.Parse(todate[0]), int.Parse(todate[1]), int.Parse(todate[2]));


            //DataTable dt = GetMaterialInStatusDataDatewise(Convert.ToDateTime(txtFromDateASD.Text), Convert.ToDateTime(txtToDateASD.Text));
            DataTable dt = GetMaterialInStatusDataDatewise(FromDateASD, ToDateASD);
            ReportDataSource rdataSource = new ReportDataSource("MaterialDataSet", dt);
            ReportViewerASD.LocalReport.DataSources.Add(rdataSource);

            //path            
            ReportViewerASD.LocalReport.ReportPath = "Report/MaterialInStatusReport.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("FromDate",txtFromDateASD.Text),
                new ReportParameter("ToDate",txtToDateASD.Text)
            };
            ReportViewerASD.LocalReport.SetParameters(rptParam);

            //refresh
            ReportViewerASD.LocalReport.Refresh();
            btnhiddenASD.Focus();
        }
        private DataTable GetMaterialInStatusDataDatewise(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("GetMaterialInputDatewise", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@From", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@To", SqlDbType.DateTime).Value = toDate;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dataTable);
            }
            return dataTable;
        }
        private void ShowMaterialOutStatusReport()
        {
            //reset
            divMaterialStatusDatewise.Visible = true;
            ReportViewerASD.Reset();

            //datasource 

            String[] fromdate = txtFromDateASD.Text.Split(new char[] { '/' });
            DateTime FromDateASD = new DateTime(int.Parse(fromdate[0]), int.Parse(fromdate[1]), int.Parse(fromdate[2]));

            String[] todate = txtToDateASD.Text.Split(new char[] { '/' });
            DateTime ToDateASD = new DateTime(int.Parse(todate[0]), int.Parse(todate[1]), int.Parse(todate[2]));


            //DataTable dt = GetMaterialOutStatusDataDatewise(Convert.ToDateTime(txtFromDateASD.Text), Convert.ToDateTime(txtToDateASD.Text));
            DataTable dt = GetMaterialOutStatusDataDatewise(FromDateASD, ToDateASD);


            ReportDataSource rdataSource = new ReportDataSource("MaterialDataSet", dt);
            ReportViewerASD.LocalReport.DataSources.Add(rdataSource);

            //path            
            ReportViewerASD.LocalReport.ReportPath = "Report/MaterialOutStatusReport.rdlc";

            //parameter
            ReportParameter[] rptParam = new ReportParameter[]
            {                
                new ReportParameter("FromDate",txtFromDateASD.Text),
                new ReportParameter("ToDate",txtToDateASD.Text)
            };
            ReportViewerASD.LocalReport.SetParameters(rptParam);

            //refresh
            ReportViewerASD.LocalReport.Refresh();
            btnhiddenASD.Focus();
        }
        private DataTable GetMaterialOutStatusDataDatewise(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("GetMaterialOutDatewise", cn);
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