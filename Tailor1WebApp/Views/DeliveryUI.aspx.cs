using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tailor1WebApp.BLL;
using Tailor1WebApp.Models;
using System.Web.Services;

namespace Tailor1WebApp.Views
{
    public partial class DeliveryUI : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        double DueAmount = 0.0;
        int OrderID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUndeliveredOrderList();
                btnSearch.Focus();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
        }

        private void LoadUndeliveredOrderList()
        {
            List<Order> listofOrderss = new List<Order>();
            listofOrderss = tailorBLL.GetAllUndeliveredOrder();
            lvAllUnDeliveredList.DataSource = listofOrderss;
            lvAllUnDeliveredList.DataBind();
        }

        int lvRowCount = 0;
        protected void lvAllUnDeliveredList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Order orderList = (Order)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkbtnOrderNo = (LinkButton)currentItem.FindControl("lnkbtnOrderNo");
                Label lblOrderDate = (Label)currentItem.FindControl("lblOrderDate");
                Label lblDeliveryDate = (Label)currentItem.FindControl("lblDeliveryDate");
                Label lblTotalPrice = (Label)currentItem.FindControl("lblTotalPrice");
                Label lblPaidAmount = (Label)currentItem.FindControl("lblPaidAmount");
                Label lblOrderID = (Label)currentItem.FindControl("lblOrderID");
                Label lblDiscount = (Label)currentItem.FindControl("lblDiscount");
                Label lblDueAmount = (Label)currentItem.FindControl("lblDueAmount");

                lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = lvRowCount.ToString();

                lnkbtnOrderNo.Text = orderList.OrderNo;
                lblOrderDate.Text = (orderList.OrderDate).ToString("dd/MM/yyyy");
                lblDeliveryDate.Text = (orderList.DeliveryDate).ToString("dd/MM/yyyy");
                lblTotalPrice.Text = orderList.Price.ToString();
                lblPaidAmount.Text = orderList.PaidAmount.ToString();
                lblDiscount.Text = orderList.Discount.ToString();
                lblDueAmount.Text = orderList.DueAmount.ToString();
                lblOrderID.Text = orderList.OrderID.ToString();
                lnkbtnOrderNo.CommandArgument = orderList.OrderID.ToString();
                lnkbtnOrderNo.CommandName = "LoadOrder";

            }
        }

        protected void lvAllUnDeliveredList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "LoadOrder")
            {
                //Response.Redirect("~/Views/MeasurementUI.aspx");
            }
        }

        protected void btnDelivery_Click(object sender, EventArgs e)
        {
            foreach (var item in lvAllUnDeliveredList.Items)
            {
                var checkBox = item.FindControl("chkboxDelivery") as CheckBox;
                if (checkBox.Checked)
                {
                    var orderID = item.FindControl("lblOrderID") as Label;
                    string OrderID = orderID.Text;
                    var due = item.FindControl("lblDueAmount") as Label;
                    DueAmount = Convert.ToDouble(due.Text);
                    //OrderID = Convert.ToInt32(orderID.Text);
                    //this.Page_Load(null, null);
                    if (DueAmount >= 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alertMe();", true);
                        //OrderDelivered(OrderID);
                        //this.Page_Load(null, null);
                        //string message = "There is some Due...Do you want to Deliver?";
                        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        //sb.Append("return confirm('");
                        //sb.Append(message);
                        //sb.Append("');");
                        //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
                        //int OrderIDforUpdate = Convert.ToInt32(orderID.Text);
                        //string DeliveryMessage = tailorBLL.UpdateOrderDelivery(OrderIDforUpdate);
                        //LoadUndeliveredOrderList();

                        //    //strbuilderr.Append("<script type = 'text/javascript'>");
                        //    //strbuilderr.Append("window.onload=function(){");
                        //    //strbuilderr.Append("confirm('");
                        //    //strbuilderr.Append(message);
                        //    //strbuilderr.Append("')};");
                        //    //strbuilderr.Append("</script>");
                        //    //ClientScript.RegisterClientScriptBlock(this.GetType(), "confirm", strbuilderr.ToString());
                    }
                    else
                    {
                        //int OrderIDforUpdate = Convert.ToInt32(orderID.Text);
                        //string DeliveryMessage = tailorBLL.UpdateOrderDelivery(OrderIDforUpdate);
                        //LoadUndeliveredOrderList();

                        //txtMessage.Focus();
                        //System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                        //strbuilder.Append("<script type = 'text/javascript'>");
                        //strbuilder.Append("window.onload=function(){");
                        //strbuilder.Append("alert('");
                        ////strbuilder.Append(DeliveryMessage);
                        //strbuilder.Append("')};");
                        //strbuilder.Append("</script>");
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                        //OrderDelivered(OrderID);
                    }
                }
            }
        }

        public void OnConfirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                foreach (var item in lvAllUnDeliveredList.Items)
                {
                    var checkBox = item.FindControl("chkboxDelivery") as CheckBox;
                    if (checkBox.Checked)
                    {
                        var orderID = item.FindControl("lblOrderID") as Label;
                        string OrderID = orderID.Text;
                        var due = item.FindControl("lblDueAmount") as Label;
                        DueAmount = Convert.ToDouble(due.Text);
                        //if (DueAmount >= 0)
                        //{
                        int OrderIDforUpdate = Convert.ToInt32(orderID.Text);
                        string DeliveryMessage = tailorBLL.UpdateOrderDelivery(OrderIDforUpdate);
                        LoadUndeliveredOrderList();
                        //}
                    }
                }
            }
            else
            {
                //Your logic for cancel button
                Response.Redirect("DeliveryUI.aspx");
            }
        }


        public void OnalertCancel(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                foreach (var item in lvAllUnDeliveredList.Items)
                {
                    var checkBox = item.FindControl("chkboxDelivery") as CheckBox;
                    if (checkBox.Checked)
                    {
                        var orderID = item.FindControl("lblOrderID") as Label;
                        int OrderIDforUpdate = Convert.ToInt32(orderID.Text);
                        if (OrderIDforUpdate > 0)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alertCancel();", true);
                            string CancelMessage = tailorBLL.CancilOrderDelivery(OrderIDforUpdate);
                            LoadUndeliveredOrderList();
                        }
                    }
                }
            }
            else
            {
                //Your logic for cancel button
                Response.Redirect("DeliveryUI.aspx");
            }
        }

        //[System.Web.Services.WebMethod]
        //private void OrderDelivered(Label orderID)
        //[WebMethod]
        //public static string OrderDelivered(string OrderID)
        //{
        //    TailorAppBLL tailorBLL = new TailorAppBLL();
        //    int OrderIDforUpdate = Convert.ToInt32(OrderID);
        //    string DeliveryMessage = tailorBLL.UpdateOrderDelivery(OrderIDforUpdate);
        //    //LoadUndeliveredOrderList();
        //    return DeliveryMessage;
        //}
        //public bool EnablePageMethods { get; set; }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchText.Text;
            List<Order> listofOrders = new List<Order>();
            listofOrders = tailorBLL.GetAllUndeliveredOrderByOrderNo(searchText);
            lvAllUnDeliveredList.DataSource = listofOrders;
            lvAllUnDeliveredList.DataBind();
        }

        protected void OnPagePropertyChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvAllUnDeliveredList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadUndeliveredOrderList();
        }

        protected void btnCancilOrder_Click(object sender, EventArgs e)
        {
            //foreach (var item in lvAllUnDeliveredList.Items)
            //{
            //    var checkBox = item.FindControl("chkboxDelivery") as CheckBox;
            //    if (checkBox.Checked)
            //    {
            //        var orderID = item.FindControl("lblOrderID") as Label;
            //        int OrderIDforUpdate = Convert.ToInt32(orderID.Text);
            //        if (OrderIDforUpdate > 0)
            //        {
            //           Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alertCancel();", true);
            //           string CancelMessage = tailorBLL.CancilOrderDelivery(OrderIDforUpdate);
            //           LoadUndeliveredOrderList();
            //        }

            //        //string message = "Are you sure about Canceling the Order ?";
            //        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //        //sb.Append("return confirm('");
            //        //sb.Append(message);
            //        //sb.Append("');");
            //        //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
            //        //string CancelMessage = tailorBLL.CancilOrderDelivery(OrderIDforUpdate);
            //        //LoadUndeliveredOrderList();
            //        //txtMessage.Focus();

            //        //System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
            //        //strbuilder.Append("<script type = 'text/javascript'>");
            //        //strbuilder.Append("window.onload=function(){");
            //        //strbuilder.Append("alert('");
            //        //strbuilder.Append(CancelMessage);
            //        //strbuilder.Append("')};");
            //        //strbuilder.Append("</script>");
            //        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
            //    }                
            //}
        }

        protected void rbUnDelivered_CheckedChanged(object sender, EventArgs e)
        {
            LoadUndeliveredOrderList();
            btnCancilOrder.Enabled = true;
            btnDelivery.Enabled = true;
        }
        protected void rbDelivered_CheckedChanged(object sender, EventArgs e)
        {
            LoadDeliveredOrderList();
            btnCancilOrder.Enabled = false;
            btnDelivery.Enabled = false;
        }
        protected void rbCancil_CheckedChanged(object sender, EventArgs e)
        {
            List<Order> listofOrderss = new List<Order>();
            listofOrderss = tailorBLL.GetAllCanceledOrder();
            lvAllUnDeliveredList.DataSource = listofOrderss;
            lvAllUnDeliveredList.DataBind();
            btnCancilOrder.Enabled = false;
            btnDelivery.Enabled = false;
        }

        private void LoadDeliveredOrderList()
        {
            List<Order> listofOrderss = new List<Order>();
            listofOrderss = tailorBLL.GetAllDeliveredOrder();
            lvAllUnDeliveredList.DataSource = listofOrderss;
            lvAllUnDeliveredList.DataBind();
        }

    }
}