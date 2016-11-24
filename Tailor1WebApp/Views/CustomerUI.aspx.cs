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
    public partial class CustomerUI : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
                btnCancil.Visible = false;
                int customerID = Convert.ToInt32(Request["value1"]);
                if (customerID > 0)
                {
                    lblCustomerHiddenID.Text = customerID.ToString();
                    List<Customer> listofCustomers = new List<Customer>();
                    listofCustomers = tailorBLL.GetAllCustomerByCustomerID(customerID);
                    foreach (var item in listofCustomers)
                    {
                        txtCustomerIDNo.Text = item.CustomerIDNo.ToString();
                        txtFullName.Text = item.Name.ToString();
                        txtDepartment.Text = item.Department.ToString();
                        txtCustomerMobile.Text = item.MobileNo.ToString();
                        txtDesignation.Text = item.Designation.ToString();
                        txtWorkStation.Text = item.WorkStation.ToString();
                        if (item.Gender == "Male")
                        {
                            rbMale.Checked = true;
                        }
                        else
                        {
                            rbFemale.Checked = true;
                        }
                        txtCustomerAddress.Text = item.Address.ToString();
                        if (item.CustomerType == "Employee")
                        {
                            rbEmployee.Checked = true;
                        }
                        else
                        {
                            rbGeneral.Checked = true;
                        }
                    }
                    btnSave.Text = "Update";
                    btnCancil.Visible = true;
                    hlCustomerSearch.Visible = false;
                }
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            aCustomer.CustomerIDNo = txtCustomerIDNo.Text;
            aCustomer.Name = txtFullName.Text;
            aCustomer.Department = txtDepartment.Text;
            aCustomer.MobileNo = txtCustomerMobile.Text;
            aCustomer.Designation = txtDesignation.Text;
            aCustomer.WorkStation = txtWorkStation.Text;
            if (rbMale.Checked)
            {
                aCustomer.Gender = "Male";
            }
            else
            {
                aCustomer.Gender = "FeMale";
            }


            aCustomer.Address = txtCustomerAddress.Text;
            if (rbEmployee.Checked)
            {
                aCustomer.CustomerType = "Employee";
            }
            else
            {
                aCustomer.CustomerType = "General";
            }

            try
            {
                if (btnSave.Text == "Update")
                {
                    int customerIdHidden = Convert.ToInt32(lblCustomerHiddenID.Text);
                    msg = tailorBLL.UpdateCustomer(aCustomer, customerIdHidden);
                    txtMessage.Text = msg.ToString();

                    ClearAllField();
                    Response.Redirect("CustomerSearch.aspx");
                }
                else
                {
                    msg = tailorBLL.SaveCustomer(aCustomer);
                    txtMessage.Text = msg.ToString();

                    Session["CustomerName"] = aCustomer.Name.ToString();
                    Session["CustomerIDNo"] = aCustomer.CustomerIDNo.ToString();

                    ClearAllField();
                    Response.Redirect("MeasurementUI.aspx");
                }
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Saving Error......Enter Correct Value";
                btnSave.Focus();
            }
        }

        public void ClearAllField()
        {
            txtCustomerIDNo.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtCustomerMobile.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtWorkStation.Text = string.Empty;
        }

        protected void rbEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGeneral.Checked)
            {
                int counter = tailorBLL.GetMaxCustomerID();
                txtCustomerIDNo.Enabled = false;
                txtCustomerIDNo.Text = "GEN-" + (counter + 1).ToString().PadLeft(5, '0');
            }
            else
            {
                txtCustomerIDNo.Enabled = true;
                txtCustomerIDNo.Text = string.Empty;
            }
        }

        protected void btnCancil_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerSearch.aspx");
        }
    }
}