using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tailor1WebApp.BLL;
using Tailor1WebApp.Models;

namespace Tailor1WebApp.Views
{
    public partial class MeasurementUI : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerDropDown();
                LoadDressTypeDropDown();
                btnCancil.Visible = false;
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
                if ((Session["CustomerIDNo"] != null) && (Session["CustomerName"] != null))
                {
                    string CID = Session["CustomerIDNo"].ToString();
                    lblCustomerName.Text = Session["CustomerName"].ToString();
                    ddlCustomer.Items.FindByText(CID).Selected = true;
                }

                int measurementID = Convert.ToInt32(Request["value1"]);                

                if (measurementID > 0)
                {
                    lblMeasurementHiddenID.Text = measurementID.ToString();
                    List<Measurement> listofMeasurements = new List<Measurement>();
                    List<Customer> customerList = new List<Customer>();
                    listofMeasurements = tailorBLL.GetAllMeasurementBymeasurementID(measurementID);
                    foreach (var item in listofMeasurements)
                    {
                        txtLength.Text = (Convert.ToDouble(item.Length)).ToString();
                        txtChest.Text = item.Chest.ToString();
                        txtWaistBelly.Text = item.WaistBelly.ToString();
                        txtHip.Text = item.Hip.ToString();
                        txtShoulder.Text = item.Shoulder.ToString();
                        txtSleeveLength.Text = item.SleeveLength.ToString();
                        txtCuffopening.Text = item.CuffOpening.ToString();
                        txtNeck.Text = item.Neck.ToString();
                        txtAllroundRise.Text = item.AllRoundRise.ToString();
                        txtThaigh.Text = item.Thaigh.ToString();
                        txtBottomOpening.Text = item.BottomOpening.ToString();
                        int customerID = Convert.ToInt32(item.CustomerID);
                        int dressTypeID = Convert.ToInt32(item.DressTypeID);
                        ddlDressType.SelectedIndex = dressTypeID;
                        ddlCustomer.SelectedIndex = customerID;
                        customerList = tailorBLL.GetAllCustomerByCustomerID(customerID);
                        foreach (var customer in customerList)
                        {
                            lblCustomerName.Text = customer.Name.ToString();
                            lblDesignation.Text = customer.Designation.ToString();
                            lblWorkStation.Text = customer.WorkStation.ToString();
                            ddlCustomer.SelectedItem.Text = customer.CustomerIDNo.ToString();
                        }
                        //string CustomerName = tailorBLL.GetCustomerNameByID(customerID);
                        //if (CustomerName == "")
                        //{
                        //    lblCustomerName.Visible = false;
                        //}
                        //else
                        //{
                        //    lblCustomerName.Text = CustomerName.ToString();
                        //}
                        lblhiddenCustomerID.Text = customerID.ToString();
                    }
                    btnSave.Text = "Update";
                    btnCancil.Visible = true;
                    hlMeasurementSearch.Visible = false;
                }                          
            }
        }

        public void LoadCustomerDropDown()
        {
            List<Customer> listofCustomers = new List<Customer>();
            listofCustomers = tailorBLL.GetAllCustomer();
            ddlCustomer.DataSource = listofCustomers;
            ddlCustomer.DataTextField = "CustomerIDNo";
            ddlCustomer.DataValueField = "CustomerID";
            ddlCustomer.DataBind();
        }

        public void LoadDressTypeDropDown()
        {
            List<DressType> listofDressTypes = new List<DressType>();
            listofDressTypes = tailorBLL.GetAllDressType();
            ddlDressType.DataSource = listofDressTypes;
            ddlDressType.DataTextField = "TypeName";
            ddlDressType.DataValueField = "DressTypeID";
            ddlDressType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Measurement aMeasurement = new Measurement();
                aMeasurement.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
                aMeasurement.DressTypeID = Convert.ToInt32(ddlDressType.SelectedValue);

                if (txtLength.Text == "")
                {
                    aMeasurement.Length = 0.0;
                }
                else
                {
                    aMeasurement.Length = Convert.ToDouble(txtLength.Text);
                }
                if (txtChest.Text == "")
                {
                    aMeasurement.Chest = 0.0;
                }
                else
                {
                    aMeasurement.Chest = Convert.ToDouble(txtChest.Text);
                }
                if (txtWaistBelly.Text == "")
                {
                    aMeasurement.WaistBelly = 0.0;
                }
                else
                {
                    aMeasurement.WaistBelly = Convert.ToDouble(txtWaistBelly.Text);
                }
                if (txtHip.Text == "")
                {
                    aMeasurement.Hip = 0.0;
                }
                else
                {
                    aMeasurement.Hip = Convert.ToDouble(txtHip.Text);
                }
                if (txtShoulder.Text == "")
                {
                    aMeasurement.Shoulder = 0.0;
                }
                else
                {
                    aMeasurement.Shoulder = Convert.ToDouble(txtShoulder.Text);
                }
                if (txtSleeveLength.Text == "")
                {
                    aMeasurement.SleeveLength = 0.0;
                }
                else
                {
                    aMeasurement.SleeveLength = Convert.ToDouble(txtSleeveLength.Text);
                }
                if (txtCuffopening.Text == "")
                {
                    aMeasurement.CuffOpening = 0.0;
                }
                else
                {
                    aMeasurement.CuffOpening = Convert.ToDouble(txtCuffopening.Text);
                }
                if (txtNeck.Text == "")
                {
                    aMeasurement.Neck = 0.0;
                }
                else
                {
                    aMeasurement.Neck = Convert.ToDouble(txtNeck.Text);
                }
                if (txtAllroundRise.Text == "")
                {
                    aMeasurement.AllRoundRise = 0.0;
                }
                else
                {
                    aMeasurement.AllRoundRise = Convert.ToDouble(txtAllroundRise.Text);
                }
                if (txtThaigh.Text == "")
                {
                    aMeasurement.Thaigh = 0.0;
                }
                else
                {
                    aMeasurement.Thaigh = Convert.ToDouble(txtThaigh.Text);
                }
                if (txtBottomOpening.Text == "")
                {
                    aMeasurement.BottomOpening = 0.0;
                }
                else
                {
                    aMeasurement.BottomOpening = Convert.ToDouble(txtBottomOpening.Text);
                }

                if (btnSave.Text == "Update")
                {
                    int measurementHiddenID = Convert.ToInt32(lblMeasurementHiddenID.Text);
                    int cusID = Convert.ToInt32(lblhiddenCustomerID.Text);
                    aMeasurement.CustomerID = cusID;
                    msg = tailorBLL.UpdateMeasurement(aMeasurement, measurementHiddenID);
                    txtMessage.Text = msg.ToString();
                    ClearAllField();
                    Response.Redirect("MeasurementSearch.aspx");
                }
                else
                {
                    msg = tailorBLL.SaveMeasurement(aMeasurement);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(msg);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

                    Session["CustomerMeasurementIDNo"] = ddlCustomer.SelectedItem.ToString();
                    ClearAllField();
                    Response.Redirect("MeasurementSearch.aspx");
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Saving Problem....Enter Correct Value";
                btnSave.Focus();
            }
        }

        private void ClearAllField()
        {
            ddlCustomer.SelectedIndex = 0;
            ddlDressType.SelectedIndex = 0;
            lblCustomerName.Text = string.Empty;
            txtLength.Text = string.Empty;
            txtChest.Text = string.Empty;
            txtWaistBelly.Text = string.Empty;
            txtHip.Text = string.Empty;
            txtShoulder.Text = string.Empty;
            txtSleeveLength.Text = string.Empty;
            txtCuffopening.Text = string.Empty;
            txtNeck.Text = string.Empty;
            txtAllroundRise.Text = string.Empty;
            txtThaigh.Text = string.Empty;
            txtBottomOpening.Text = string.Empty;
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
            List<Customer> customerList = new List<Customer>();
            customerList = tailorBLL.GetAllCustomerByCustomerID(CustomerID);
            foreach (var customer in customerList)
            {
                lblCustomerName.Text = customer.Name.ToString();
                lblDesignation.Text = customer.Designation.ToString();
                lblWorkStation.Text = customer.WorkStation.ToString();
            }
            //string CustomerName = tailorBLL.GetCustomerNameByID(CustomerID);
            //if (CustomerName == "")
            //{
            //    lblCustomerName.Visible = false;
            //}
            //else
            //{
            //    lblCustomerName.Text = CustomerName.ToString();
            //}
        }

        protected void btnCancil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeasurementSearch.aspx");
        }
    }
}