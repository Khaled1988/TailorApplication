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
    public partial class OrderMaterialSearch : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSearch.Focus();
                btnModify.Visible = false;
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                //string searchText = txtOrderNo.Text.Trim();

                String[] FromDateASD = txtFromDate.Text.Split(new char[] { '/' });
                DateTime fromDate = new DateTime(int.Parse(FromDateASD[0]), int.Parse(FromDateASD[1]), int.Parse(FromDateASD[2]));

                String[] ToDateASD = txtToDate.Text.Split(new char[] { '/' });
                DateTime toDate = new DateTime(int.Parse(ToDateASD[0]), int.Parse(ToDateASD[1]), int.Parse(ToDateASD[2]));


                //DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                //DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                string fromDATE = fromDate.ToString();  // fromDate.Year.ToString() + "/" + fromDate.Month.ToString() + "/" + fromDate.Day.ToString();
                string toDATE = toDate.ToString();                        //  toDate.Year.ToString() + "/" + toDate.Month.ToString() + "/" + toDate.Day.ToString();

                List<OrderMaterial> listofOrderMaterial = new List<OrderMaterial>();
                listofOrderMaterial = tailorBLL.GetMaterialRequsitionBetweenFromToDate(fromDATE, toDATE);

                //listofOrderMaterial = tailorBLL.GetOrderMaterialByOrderNo(searchText);
                if (listofOrderMaterial.Count > 0)
                {
                    lvOrderMaterial.DataSource = listofOrderMaterial;
                    lvOrderMaterial.DataBind();
                    btnModify.Visible = true;
                    txtMessage.Text = "";
                }
            }
            else
            {
                txtMessage.Text = "Plese Insert both Date ";
            }
        }

        protected void OnPagePropertyChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvOrderMaterial.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            //LoadCustomerList();
        }

        int lvRowCount = 0;
        protected void lvOrderMaterial_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                OrderMaterial orderMaterial = (OrderMaterial)((ListViewDataItem)(e.Item)).DataItem;

                Label lblOrderNo = (Label)currentItem.FindControl("lblOrderNo");
                Label lblOrderID = (Label)currentItem.FindControl("lblOrderID");
                Label lblMaterialCode = (Label)currentItem.FindControl("lblMaterialCode");
                Label lblMaterialQuantity = (Label)currentItem.FindControl("lblMaterialQuantity");
                Label lblMaterialOutDate = (Label)currentItem.FindControl("lblMaterialOutDate");
                Label lblMaterialUnit = (Label)currentItem.FindControl("lblMaterialUnit");

                //lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = lvRowCount.ToString();

                lblOrderNo.Text = orderMaterial.OrderNo;
                lblOrderID.Text = orderMaterial.OrderID.ToString();
                lblMaterialCode.Text = orderMaterial.MaterialCode;
                lblMaterialQuantity.Text = orderMaterial.MaterialQuantity.ToString();
                lblMaterialOutDate.Text = orderMaterial.OrderMaterialDate.ToString("dd/MM/yyyy");
                lblorderIdHidden.Text = lblOrderID.Text;
                lblMaterialUnit.Text = orderMaterial.MaterialUnit.ToString();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            //Response.Redirect("OrderMaterialCollection.aspx?OrderNo=" + txtOrderNo.Text + "&OrderID=" + lblorderIdHidden.Text);
            foreach (var item in lvOrderMaterial.Items)
            {
                var checkBox = item.FindControl("chkboxInvoice") as CheckBox;
                if (checkBox.Checked)
                {
                    var orderID = item.FindControl("lblOrderID") as Label;
                    var orderNO = item.FindControl("lblOrderNo") as Label;

                    string OrderID = orderID.Text;
                    string OrderNo = orderNO.Text;
                    Response.Redirect("OrderMaterialCollection.aspx?OrderNo=" + OrderNo + "&OrderID=" + OrderID);
                }
            }
        }
    }
}