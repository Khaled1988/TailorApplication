using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Tailor1WebApp.BLL;
using Tailor1WebApp.Models;

namespace Tailor1WebApp.Views
{
    public partial class OrderUI : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerDropDown();
                btnCalculate.Visible = false;
                btnReceipt.Enabled = false;
                quantityDiv.Visible = false;
                LoadOrderNo();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
        }
        private void LoadOrderNo()
        {
            List<Order> orderList = new List<Order>();
            orderList = tailorBLL.GetAllOrder();
            if (orderList.Count > 0)
            {
                int counter = tailorBLL.GetMaxOrderID();
                txtOrderNo.Enabled = false;
                //txtOrderNo.Text = "USBF-" + (counter + 1).ToString().PadLeft(5, '0');     
                txtOrderNo.Text = "Invoice-" + (counter + 1).ToString().PadLeft(5, '0');
            }
            else
            {
                int counter = 0;
                txtOrderNo.Enabled = false;
                //txtOrderNo.Text = "USBF-" + (counter + 1).ToString().PadLeft(5, '0');    
                txtOrderNo.Text = "Invoice-" + (counter + 1).ToString().PadLeft(5, '0');
            }

        }
        public void LoadCustomerDropDown()
        {
            List<Customer> listofCustomers = new List<Customer>();
            listofCustomers = tailorBLL.GetAllCustomer();
            ddlCustomerList.DataSource = listofCustomers;
            ddlCustomerList.DataTextField = "CustomerIDNo";
            ddlCustomerList.DataValueField = "CustomerID";
            ddlCustomerList.DataBind();
        }

        protected void ddlCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(ddlCustomerList.SelectedValue);
            List<Customer> customerList = new List<Customer>();
            customerList = tailorBLL.GetAllCustomerByCustomerID(CustomerID);
            foreach (var customer in customerList)
            {
                lblCustomerName.Text = customer.Name.ToString();
                lblDesignation.Text = customer.Designation.ToString();
            }
            List<DressMeasurement> dressMeasurementList = new List<DressMeasurement>();
            dressMeasurementList = tailorBLL.GetDressMeasurementListByCustomerID(CustomerID);
            lvCustomerMeasurement.DataSource = dressMeasurementList;
            lvCustomerMeasurement.DataBind();
            btnCalculate.Visible = true;

        }

        int lvRowCount = 0;
        protected void lvCustomerMeasurement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                //Customer brand = (Customer)((ListViewDataItem)(e.Item)).DataItem;
                DressMeasurement dressMeasurement = (DressMeasurement)((ListViewDataItem)(e.Item)).DataItem;

                Label lblDressType = (Label)currentItem.FindControl("lblDressType");
                Label lblPrice = (Label)currentItem.FindControl("lblPrice");
                TextBox txtDressQuantity = (TextBox)currentItem.FindControl("txtDressQuantity");
                Label lblDressTypeID = (Label)currentItem.FindControl("lblDressTypeID");

                lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                lblSerialNo.Text = lvRowCount.ToString();

                lblDressType.Text = dressMeasurement.DressType;
                lblPrice.Text = dressMeasurement.DressPrice.ToString();
                lblDressTypeID.Text = dressMeasurement.DressTypeID.ToString();

            }
        }

        double due = 0.0;
        int orderID = 0;
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double price = 0.0;
            double paidAmount = 0.0;
            double discount = 0.0;
            int Totalquantity = 0;

            foreach (var item in lvCustomerMeasurement.Items)
            {
                var dress = item.FindControl("lblDressType") as Label;
                var pricelabel = item.FindControl("lblPrice") as Label;
                var quantitylabel = item.FindControl("txtDressQuantity") as TextBox;
                var dressTypeID = item.FindControl("lblDressTypeID") as Label;
                var txtMaterialCode = item.FindControl("txtMaterialCode") as TextBox;

                string dressType = dress.Text;
                double pricevalue = Convert.ToInt64(pricelabel.Text);
                int DressTypeID = Convert.ToInt32(dressTypeID.Text);
                int Quantity = 0;
                if (quantitylabel.Text != "")
                {
                    Quantity = Convert.ToInt32(quantitylabel.Text);
                    price += pricevalue;
                    price *= Quantity;
                    Totalquantity += Quantity;
                }
            }

            txtTotalPrice.Text = price.ToString();
            txtPaidAmount.Text = paidAmount.ToString();
            txtDue.Text = price.ToString();
            txtDiscount.Text = discount.ToString();
            txtTotalQuantity.Text = (Convert.ToInt64(Totalquantity)).ToString();
            btnSave.Focus();
        }
        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            double paidAmount = Convert.ToInt64(txtPaidAmount.Text);
            double totalPrice = Convert.ToInt64(txtTotalPrice.Text);
            txtDue.Text = (totalPrice - paidAmount).ToString();
            btnSave.Focus();
        }
        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            double paidAmount = Convert.ToInt64(txtPaidAmount.Text);
            double discountAmount = Convert.ToInt64(txtDiscount.Text);
            double totalPrice = Convert.ToInt64(txtTotalPrice.Text);
            txtDue.Text = (totalPrice - paidAmount - discountAmount).ToString();
            due = totalPrice - paidAmount - discountAmount;
            btnSave.Focus();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Order aOrder = new Order();
            aOrder.CustomerID = Convert.ToInt32(ddlCustomerList.SelectedValue);
            aOrder.OrderNo = txtOrderNo.Text;
            aOrder.OrderDate = System.DateTime.Now;
            aOrder.DeliveryDate = Convert.ToDateTime(txtDelivereyDate.Text);
            aOrder.Price = Convert.ToInt64(txtTotalPrice.Text);
            aOrder.Quantity = Convert.ToInt32(txtTotalQuantity.Text);
            aOrder.PaidAmount = Convert.ToInt64(txtPaidAmount.Text);
            aOrder.Discount = Convert.ToInt64(txtDiscount.Text);
            aOrder.DueAmount = Convert.ToInt64(txtDue.Text);
            double dueAmount = Convert.ToInt64(txtDue.Text);
            aOrder.Remarks = txtRemarks.Text;
            if (dueAmount > 0.0)
            {
                aOrder.PaymentStatus = 1;  // unpaid
            }
            else
            {
                aOrder.PaymentStatus = 0; // fully paid
            }
            aOrder.DeliveryStatus = 1;  // undelivered
            aOrder.CancilStatus = 1; // not cancil

            try
            {
                string msg = tailorBLL.SaveOrder(aOrder);
                if (msg == "Order No Already Exist")
                {
                    return;
                }
                else
                {
                    orderID = tailorBLL.GetOrderIDbyOrderNo(txtOrderNo.Text);

                    foreach (var item in lvCustomerMeasurement.Items)
                    {
                        var dress = item.FindControl("lblDressType") as Label;
                        var pricelabel = item.FindControl("lblPrice") as Label;
                        var quantitylabel = item.FindControl("txtDressQuantity") as TextBox;
                        var dressTypeID = item.FindControl("lblDressTypeID") as Label;

                        if (quantitylabel.Text != "")
                        {
                            int dressQuantity = Convert.ToInt32(quantitylabel.Text);
                            double dressPrice = Convert.ToInt64(pricelabel.Text);
                            double TotalDressPrice = dressPrice * (double)dressQuantity;
                            OrderDetail aOrderDetail = new OrderDetail();
                            aOrderDetail.DressTypeID = Convert.ToInt32(dressTypeID.Text);
                            aOrderDetail.Quantity = Convert.ToInt32(quantitylabel.Text);
                            aOrderDetail.Price = TotalDressPrice;
                            aOrderDetail.OrderID = orderID;
                            string orderDetailmsg = tailorBLL.SaveOrderDetails(aOrderDetail);
                        }
                    }
                }

                System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                strbuilder.Append("<script type = 'text/javascript'>");
                strbuilder.Append("window.onload=function(){");
                strbuilder.Append("alert('");
                strbuilder.Append(msg);
                strbuilder.Append("')};");
                strbuilder.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                txtMessage.Visible = false;
                txtOrderNohidden.Text = txtOrderNo.Text.ToString();
                ClearAllField();
                btnSave.Enabled = false;
                btnCalculate.Enabled = false;
                btnReceipt.Enabled = true;
                btnReceipt.Focus();
            }
            catch (Exception ex)
            {
                txtMessage.Text = "Saving Error......Enter Correct Value";
            }

        }
        private void ClearAllField()
        {
            ddlCustomerList.SelectedIndex = 0;
            txtOrderNo.Text = string.Empty;
            txtDelivereyDate.Text = string.Empty;
            txtTotalPrice.Text = string.Empty;
            txtTotalQuantity.Text = string.Empty;
            txtPaidAmount.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtDue.Text = string.Empty;
            lvCustomerMeasurement.Visible = false;
            txtRemarks.Text = string.Empty;
            lblCustomerName.Text = "";
            lblDesignation.Text = "";

        }
        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            string orderReceiptNo = txtOrderNohidden.Text.ToString();
            Response.Redirect("OrderReceipt.aspx?Name=" + orderReceiptNo);
            //ShowReport();
        }
        //List<Material> materialList = new List<Material>();
        
        
    }
}