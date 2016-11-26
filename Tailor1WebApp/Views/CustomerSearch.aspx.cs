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
    public partial class TestListView : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerList();
                btnSearch.Focus();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
        }

        private void LoadCustomerList()
        {
            List<Customer> listofCustomers = new List<Customer>();
            listofCustomers = tailorBLL.GetAllCustomer();
            if (listofCustomers.Count>0)
            {
                lvAllBrandList.DataSource = listofCustomers;
                lvAllBrandList.DataBind();
            }
            else
            {
                lvAllBrandList.DataSource = null;
                lvAllBrandList.DataBind();
            }
            
        }

        

        int lvRowCount = 0;
        protected void lvAllBrandList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Customer customer = (Customer)((ListViewDataItem)(e.Item)).DataItem;
                //LinkButton lnkbtnName = (LinkButton)currentItem.FindControl("lnkbtnName");lblName
                Label lblName = (Label)currentItem.FindControl("lblName");
                Label lblCUstomerIDNo = (Label)currentItem.FindControl("lblCUstomerIDNo");
                Label lblDepartment = (Label)currentItem.FindControl("lblDepartment");
                Label lblDesignation = (Label)currentItem.FindControl("lblDesignation");
                Label lblMobileNo = (Label)currentItem.FindControl("lblMobileNo");
                Label lblCustomerID = (Label)currentItem.FindControl("lblCustomerID");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkMeasurement = (LinkButton)currentItem.FindControl("lnkMeasurement");

                lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = lvRowCount.ToString();

                //lnkbtnName.Text = customer.Name;
                lblName.Text = customer.Name;
                lblCUstomerIDNo.Text = customer.CustomerIDNo;
                lblDepartment.Text = customer.Department;
                lblDesignation.Text = customer.Designation;
                lblMobileNo.Text = customer.MobileNo;
                lblCustomerID.Text = customer.CustomerID.ToString();
                //lnkbtnName.CommandArgument = customer.CustomerID.ToString();
                //lnkbtnName.CommandName = "LoadBrand";
                lnkEdit.CommandArgument = customer.CustomerID.ToString();
                lnkEdit.CommandName = "EditCustomer";
                lnkMeasurement.CommandArgument = customer.CustomerID.ToString();
                lnkMeasurement.CommandName = "CustomerMeasurement";
            }
        }

        protected void lvAllBrandList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "CustomerMeasurement")
            {
                int customerID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Views/MeasurementSearch.aspx?customerid=" + customerID);
            }
            else if (e.CommandName == "EditCustomer")
            {
                int customerID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Views/CustomerUI.aspx?customerid=" + customerID);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Customer> listofCustomers = new List<Customer>();
            string CustomerName = txtCustomerName.Text.Trim();
            string customerID = txtCustomerID.Text.Trim();
            string customerMobile = txtCustomerMobile.Text.Trim();
            if (customerID =="" && CustomerName =="" && customerMobile =="")
            {
                LoadCustomerList();
            }
            else
            {
                if (CustomerName !="")
                {
                    listofCustomers = tailorBLL.GetAllCustomerByName(CustomerName);
                    if (listofCustomers.Count>0)
                    {
                        lvAllBrandList.DataSource = listofCustomers;
                        lvAllBrandList.DataBind();
                    }
                    else
                    {
                        lvAllBrandList.DataSource = null;
                        lvAllBrandList.DataBind();
                    }
                }
                else if (customerID!="")
                {
                    listofCustomers = tailorBLL.GetAllCustomerByID(customerID);
                    if (listofCustomers.Count > 0)
                    {
                        lvAllBrandList.DataSource = listofCustomers;
                        lvAllBrandList.DataBind();
                    }
                    else
                    {
                        lvAllBrandList.DataSource = null;
                        lvAllBrandList.DataBind();
                    }
                }
                else
                {
                    listofCustomers = tailorBLL.GetAllCustomerByMobile(customerMobile);
                    if (listofCustomers.Count > 0)
                    {
                        lvAllBrandList.DataSource = listofCustomers;
                        lvAllBrandList.DataBind();
                    }
                    else
                    {
                        lvAllBrandList.DataSource = null;
                        lvAllBrandList.DataBind();
                    }
                }
            }
            
            //listofCustomers = tailorBLL.GetAllCustomerByName(searchText);
            //lvAllBrandList.DataSource = listofCustomers;
            //lvAllBrandList.DataBind();
        }

        protected void OnPagePropertyChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvAllBrandList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadCustomerList();
        }
    }
}