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
    public partial class OrderMaterialCollection : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        string CustomerName;
        string OrderNoFromSearch;
        int OrderIDFromSearch;
        List<CustomerDressOrder> CustomerDressOrderList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtOrderMaterialDate.Enabled = false;
                txtOrderMaterialDate.Text = System.DateTime.Now.ToShortDateString();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
                if (Request["OrderNo"] != null)
                {
                    OrderNoFromSearch = Request["OrderNo"].ToString();
                    OrderIDFromSearch = Convert.ToInt32(Request["OrderID"]);
                    lblorderIDSearch.Text = OrderIDFromSearch.ToString();
                    lblOrderNoSearch.Text = OrderNoFromSearch.ToString();
                    ddlOrderNo.SelectedItem.Text = OrderNoFromSearch.ToString();
                    ddlOrderNo.SelectedIndex = OrderIDFromSearch;
                    CustomerDressOrderList = new List<CustomerDressOrder>();
                    CustomerDressOrderList = tailorBLL.GetCustomerDressOrderListByOrderNo(OrderNoFromSearch);
                    lvCustomerDressOrder.DataSource = CustomerDressOrderList;
                    lvCustomerDressOrder.DataBind();
                    divCustomerName.Visible = true;
                    //txtCustomerName.Text = CustomerName.ToString();
                    foreach (var aCustomerDress in CustomerDressOrderList)
                    {
                        txtCustomerName.Text = aCustomerDress.CustomerName.ToString();
                        txtDesignation.Text = aCustomerDress.Designation.ToString();
                    }
                    btnSaveOrderMaterial.Text = "Update";
                }
                else
                {
                    LoadOrderNo();
                    divCustomerName.Visible = false;
                }
                LoadMaterialCode();

            }
        }
        private void LoadOrderNo()
        {
            List<Order> listofOrders = new List<Order>();
            listofOrders = tailorBLL.GetAllOrder();
            ddlOrderNo.DataSource = listofOrders;
            ddlOrderNo.DataTextField = "OrderNo";
            ddlOrderNo.DataValueField = "OrderID";
            ddlOrderNo.DataBind();
        }
        public void LoadMaterialCode()
        {
            List<Material> listofMaterials = new List<Material>();
            listofMaterials = tailorBLL.GetAllMaterial();
            ddlMaterialCode.DataSource = listofMaterials;
            ddlMaterialCode.DataTextField = "MaterialCode";
            ddlMaterialCode.DataValueField = "MaterialID";
            ddlMaterialCode.DataBind();
        }
        protected void btnMaterialAdd_Click(object sender, EventArgs e)
        {
            if (ddlMaterialCode.SelectedIndex != 0)
            {
                if (!string.IsNullOrWhiteSpace(txtMaterialQuantity.Text))
                {
                    lblMessage.Text = string.Empty;
                    List<Material> materialList = new List<Material>();
                    materialList = GetMaterialListInput();
                    if (lvMaterialList.Items.Count > 0)
                    {
                        foreach (var item in lvMaterialList.Items)
                        {
                            var lblMaterialCode = item.FindControl("lblMaterialCode") as Label;
                            var lblQuantity = item.FindControl("lblQuantity") as Label;
                            var lblUnit = item.FindControl("lblUnit") as Label;
                            var lblMaterialID = item.FindControl("lblMaterialID") as Label;

                            Material aMaterial = new Material();
                            aMaterial.MaterialCode = lblMaterialCode.Text;
                            aMaterial.MaterialQuantity = Convert.ToDouble(lblQuantity.Text);
                            aMaterial.Unit = lblUnit.Text;
                            aMaterial.MaterialID = Convert.ToInt32(lblMaterialID.Text);
                            materialList.Add(aMaterial);
                        }
                    }
                    if (materialList.Count > 0)
                    {
                        lvMaterialList.DataSource = materialList;
                        lvMaterialList.DataBind();
                        txtMaterialQuantity.Text = string.Empty;
                        ddlMaterialCode.SelectedIndex = 0;
                    }
                }
                else
                {
                    lblMessage.Text = "Please Enter Quantity";
                }
            }
            else
            {
                lblMessage.Text = "Please select Material";
            }

        }
        private List<Material> GetMaterialListInput()
        {
            List<Material> materialList = new List<Material>();
            Material aMaterial = new Material();
            aMaterial.MaterialCode = ddlMaterialCode.SelectedItem.ToString();
            aMaterial.MaterialQuantity = Convert.ToDouble(txtMaterialQuantity.Text);
            string measurementUnit = tailorBLL.GetMaterialUnitByCode(ddlMaterialCode.SelectedItem.ToString());
            aMaterial.Unit = measurementUnit.ToString();
            aMaterial.MaterialID = Convert.ToInt32(ddlMaterialCode.SelectedValue);
            materialList.Add(aMaterial);
            return materialList;
        }

        int lvRowCount = 0;
        protected void lvMaterialList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Material material = (Material)((ListViewDataItem)(e.Item)).DataItem;

                Label lblMaterialCode = (Label)currentItem.FindControl("lblMaterialCode");
                Label lblQuantity = (Label)currentItem.FindControl("lblQuantity");
                Label lblUnit = (Label)currentItem.FindControl("lblUnit");
                Label lblMaterialID = (Label)currentItem.FindControl("lblMaterialID");

                lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = lvRowCount.ToString();

                Material materialDetail = (Material)((ListViewDataItem)(e.Item)).DataItem;

                lblMaterialCode.Text = materialDetail.MaterialCode.ToString();
                lblQuantity.Text = materialDetail.MaterialQuantity.ToString();
                //lblUnit.Text = ddlMeasurementUnit.SelectedItem.ToString();
                lblUnit.Text = materialDetail.Unit;
                lblMaterialID.Text = materialDetail.MaterialID.ToString();
            }
        }
        protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string OrderNo = ddlOrderNo.SelectedItem.ToString();
            CustomerDressOrderList = new List<CustomerDressOrder>();
            CustomerDressOrderList = tailorBLL.GetCustomerDressOrderListByOrderNo(OrderNo);
            lvCustomerDressOrder.DataSource = CustomerDressOrderList;
            lvCustomerDressOrder.DataBind();
            divCustomerName.Visible = true;
            foreach (var aCustomerDress in CustomerDressOrderList)
            {
                txtCustomerName.Text = aCustomerDress.CustomerName.ToString();
                txtDesignation.Text = aCustomerDress.Designation.ToString();

            }
        }
        protected void lvCustomerDressOrder_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                CustomerDressOrder customerDressOrder = (CustomerDressOrder)((ListViewDataItem)(e.Item)).DataItem;

                Label lblOrderNo = (Label)currentItem.FindControl("lblOrderNo");
                Label lblCustomer = (Label)currentItem.FindControl("lblCustomer");
                Label lblDress = (Label)currentItem.FindControl("lblDress");
                Label lblOrderDate = (Label)currentItem.FindControl("lblOrderDate");
                Label lblDeliveryDate = (Label)currentItem.FindControl("lblDeliveryDate");

                lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                // lblSerialNo.Text = lvRowCount.ToString();

                lblOrderNo.Text = customerDressOrder.OrderNo.ToString();
                lblCustomer.Text = customerDressOrder.CustomerName.ToString();
                CustomerName = lblCustomer.Text;
                lblDress.Text = customerDressOrder.DressType.ToString();
                lblOrderDate.Text = customerDressOrder.OrderDate.ToShortDateString();
                lblDeliveryDate.Text = customerDressOrder.DeliveryDate.ToShortDateString();
            }
        }

        string OrderMaterialMsg;
        protected void btnSaveOrderMaterial_Click(object sender, EventArgs e)
        {
            List<OrderMaterial> orderMaterialList = new List<OrderMaterial>();
            if (txtOrderMaterialDate.Text == "" || lvMaterialList.Items.Count < 1)
            {
                lblMessage.Text = "Add All field values correctly";
            }
            else
            {
                foreach (var item in lvMaterialList.Items)
                {
                    var lblMaterialCode = item.FindControl("lblMaterialCode") as Label;
                    var lblQuantity = item.FindControl("lblQuantity") as Label;
                    var lblUnit = item.FindControl("lblUnit") as Label;
                    var lblMaterialID = item.FindControl("lblMaterialID") as Label;

                    OrderMaterial orderMaterial = new OrderMaterial();
                    orderMaterial.MaterialCode = lblMaterialCode.Text.ToString();
                    orderMaterial.MaterialQuantity = Convert.ToDouble(lblQuantity.Text);
                    orderMaterial.OrderMaterialDate = Convert.ToDateTime(txtOrderMaterialDate.Text);
                    int OrderID = Convert.ToInt32(ddlOrderNo.SelectedValue);
                    if (OrderID < 1)
                    {
                        orderMaterial.OrderID = Convert.ToInt32(lblorderIDSearch.Text);
                    }
                    else
                    {
                        orderMaterial.OrderID = OrderID;
                    }

                    orderMaterial.OrderNo = ddlOrderNo.SelectedItem.ToString();
                    orderMaterialList.Add(orderMaterial);

                    //OrderMaterialMsg = tailorBLL.SaveOrderMaterial(orderMaterial);
                }
                if (btnSaveOrderMaterial.Text == "Update")
                {
                    OrderMaterialMsg = tailorBLL.UpdateOrderMaterial(orderMaterialList, lblOrderNoSearch.Text);
                    ddlOrderNo.SelectedIndex = 0;
                }
                else
                {
                    OrderMaterialMsg = tailorBLL.SaveOrderMaterial(orderMaterialList);
                }

                System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                strbuilder.Append("<script type = 'text/javascript'>");
                strbuilder.Append("window.onload=function(){");
                strbuilder.Append("alert('");
                strbuilder.Append(OrderMaterialMsg);
                strbuilder.Append("')};");
                strbuilder.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                ClearAllField();
            }
        }
        private void ClearAllField()
        {
            txtOrderMaterialDate.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            ddlOrderNo.SelectedIndex = 0;
            txtMaterialQuantity.Text = string.Empty;
            lvCustomerDressOrder.Visible = false;
            lvMaterialList.Visible = false;
            ddlMaterialCode.SelectedIndex = 0;
            lblMessage.Text = "";
            txtDesignation.Text = string.Empty;
        }
    }
}