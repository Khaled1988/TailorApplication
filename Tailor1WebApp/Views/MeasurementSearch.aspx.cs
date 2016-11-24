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
    public partial class MeasurementSearch : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMeasurementList();
                btnSearch.Focus();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
        }

        private void LoadMeasurementList()
        {
            List<CustomerMeasurement> listofCustomerMeasurements = new List<CustomerMeasurement>();
            listofCustomerMeasurements = tailorBLL.GetAllCustomerMeasurement();
            lvAllMeasurementList.DataSource = listofCustomerMeasurements;
            lvAllMeasurementList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchText.Text;
            List<CustomerMeasurement> listofCustomerMeasurements = new List<CustomerMeasurement>();
            listofCustomerMeasurements = tailorBLL.GetAllCustomerMeasurementByName(searchText);
            lvAllMeasurementList.DataSource = listofCustomerMeasurements;
            lvAllMeasurementList.DataBind();
        }

        int lvRowCount = 0;
        protected void lvAllMeasurementList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                CustomerMeasurement customerMeasurement = (CustomerMeasurement)((ListViewDataItem)(e.Item)).DataItem;
                //LinkButton lnkbtnCustomerName = (LinkButton)currentItem.FindControl("lnkbtnCustomerName");
                Label lblName = (Label)currentItem.FindControl("lblName");
                Label lblDressType = (Label)currentItem.FindControl("lblDressType");
                Label lblLength = (Label)currentItem.FindControl("lblLength");
                Label lblChest = (Label)currentItem.FindControl("lblChest");
                Label lblWaist = (Label)currentItem.FindControl("lblWaist");
                Label lblHip = (Label)currentItem.FindControl("lblHip");
                Label lblShoulder = (Label)currentItem.FindControl("lblShoulder");
                Label lblSleeve = (Label)currentItem.FindControl("lblSleeve");
                Label lblCuff = (Label)currentItem.FindControl("lblCuff");
                Label lblNeck = (Label)currentItem.FindControl("lblNeck");
                Label lblAllRoundRise = (Label)currentItem.FindControl("lblAllRoundRise");
                Label lblThaigh = (Label)currentItem.FindControl("lblThaigh");
                Label lblBottomOpening = (Label)currentItem.FindControl("lblBottomOpening");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkPrint = (LinkButton)currentItem.FindControl("lnkPrint");
                Label lblCustomerID = (Label)currentItem.FindControl("lblCustomerID");
                Label lblMobileNo = (Label)currentItem.FindControl("lblMobileNo");

                lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = lvRowCount.ToString();

                //lnkbtnCustomerName.Text = customerMeasurement.CustomerName;
                lblName.Text = customerMeasurement.CustomerName;
                lblDressType.Text = customerMeasurement.DressTypeName;
                lblLength.Text = customerMeasurement.Length.ToString();
                lblChest.Text = customerMeasurement.Chest.ToString();
                lblWaist.Text = customerMeasurement.WaistBelly.ToString();
                lblHip.Text = customerMeasurement.Hip.ToString();
                lblShoulder.Text = customerMeasurement.Shoulder.ToString();
                lblSleeve.Text = customerMeasurement.SleeveLength.ToString();
                lblCuff.Text = customerMeasurement.CuffOpening.ToString();
                lblNeck.Text = customerMeasurement.Neck.ToString();
                lblAllRoundRise.Text = customerMeasurement.AllRoundRise.ToString();
                lblThaigh.Text = customerMeasurement.Thaigh.ToString();
                lblBottomOpening.Text = customerMeasurement.BottomOpening.ToString();
                //lnkbtnCustomerName.CommandArgument = customerMeasurement.CustomerMeasurementID.ToString();
                lblCustomerID.Text = customerMeasurement.CustomerIDCard.ToString();
                lblMobileNo.Text = customerMeasurement.CustomerMobile.ToString();
                //lnkbtnCustomerName.CommandName = "LoadBrand";
                lnkEdit.CommandArgument = customerMeasurement.MeasurementID.ToString();
                lnkEdit.CommandName = "EditMeasurement";
                lnkPrint.CommandArgument = customerMeasurement.MeasurementID.ToString();
                lnkPrint.CommandName = "PrintMeasurement";
            }
        }

        protected void lvAllMeasurementList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "LoadBrand")
            {
                //Response.Redirect("~/Views/OrderUI.aspx");
            }
            else if (e.CommandName == "EditMeasurement")
            {
                int measurementID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Views/MeasurementUI.aspx?value1=" + measurementID);
            }
            else if (e.CommandName == "PrintMeasurement")
            {
                int measurementID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Views/OrderReceipt.aspx?meID=" + measurementID);
            }
        }

        protected void OnPagePropertyChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvAllMeasurementList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadMeasurementList();
        }
    }
}