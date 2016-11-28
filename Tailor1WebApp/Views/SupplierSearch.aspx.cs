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
    public partial class SupplierSearch : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSupplierProductList();
                btnSearch.Focus();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
            }
        }

        private void LoadSupplierProductList()
        {
            List<SupplierProduct> listofSupplierProducts = new List<SupplierProduct>();
            listofSupplierProducts = tailorBLL.GetAllSupplierProduct();
            if (listofSupplierProducts.Count>0)
            {
                lvAllSupplierList.DataSource = listofSupplierProducts;
                lvAllSupplierList.DataBind();
            }
            else
            {
                lvAllSupplierList.DataSource = null;
                lvAllSupplierList.DataBind();
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<SupplierProduct> listofSupplierProducts = new List<SupplierProduct>();
            string suppliarName = txtSuplierName.Text.Trim();
            string supplierMobile = txtSuplierPhone.Text.Trim();
            if (suppliarName=="" && supplierMobile =="")
            {
                LoadSupplierProductList();
            }
            else
            {
                if (txtSuplierName.Text!="")
                {
                    listofSupplierProducts = tailorBLL.GetAllSupplierProductBySupplierName(suppliarName);
                    if (listofSupplierProducts.Count > 0)
                    {
                        lvAllSupplierList.DataSource = listofSupplierProducts;
                        lvAllSupplierList.DataBind();
                    }
                    else
                    {
                        lvAllSupplierList.DataSource = null;
                        lvAllSupplierList.DataBind();
                    }
                }
                else
                {
                    listofSupplierProducts = tailorBLL.GetAllSupplierProductBySupplierMobile(supplierMobile);
                    if (listofSupplierProducts.Count > 0)
                    {
                        lvAllSupplierList.DataSource = listofSupplierProducts;
                        lvAllSupplierList.DataBind();
                    }
                    else
                    {
                        lvAllSupplierList.DataSource = null;
                        lvAllSupplierList.DataBind();
                    }
                }
            }
            //if (searchText !="")
            //{
            //    List<SupplierProduct> listofSupplierProducts = new List<SupplierProduct>();
            //    listofSupplierProducts = tailorBLL.GetAllSupplierProductBySupplierName(searchText);

            //    if (listofSupplierProducts.Count > 0)
            //    {
            //        lvAllSupplierList.DataSource = listofSupplierProducts;
            //        lvAllSupplierList.DataBind();
            //    }
            //    else
            //    {
            //        lvAllSupplierList.DataSource = null;
            //        lvAllSupplierList.DataBind();
            //    }
            //}
            //else
            //{                
            //    LoadSupplierProductList();
            //}
            
        }

        protected void lvAllSupplierList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                SupplierProduct supplierProduct = (SupplierProduct)((ListViewDataItem)(e.Item)).DataItem;

                Label lblSupplierCode = (Label)currentItem.FindControl("lblSupplierCode");
                Label lblSupplierName = (Label)currentItem.FindControl("lblSupplierName");
                Label lblAddress = (Label)currentItem.FindControl("lblAddress");
                Label lblMobile = (Label)currentItem.FindControl("lblMobile");
                Label lblAccesories = (Label)currentItem.FindControl("lblAccesories");
                Label lblPrice = (Label)currentItem.FindControl("lblPrice");
                Label lblQuantity = (Label)currentItem.FindControl("lblQuantity");
                Label lblUnit = (Label)currentItem.FindControl("lblUnit");
                Label lblMaterialCode = (Label)currentItem.FindControl("lblMaterialCode");
                Label lblPurchaseDate = (Label)currentItem.FindControl("lblPurchaseDate");
                Label lblOtherInfo = (Label)currentItem.FindControl("lblOtherInfo");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                Label lblMaterialID = (Label)currentItem.FindControl("lblMaterialID");

                //lvRowCount += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = lvRowCount.ToString();

                lblSupplierCode.Text = supplierProduct.SupplierCode;
                lblSupplierName.Text = supplierProduct.SupplierName;
                lblAddress.Text = supplierProduct.SupplierAddress;
                lblMobile.Text = supplierProduct.SupplierMobile;
                lblAccesories.Text = supplierProduct.MaterialName;
                lblPrice.Text = supplierProduct.MaterialPrice.ToString();
                lblQuantity.Text = supplierProduct.MaterialQuantity.ToString();
                lblUnit.Text = supplierProduct.MaterialUnit;
                lblMaterialCode.Text = supplierProduct.MaterialCode;
                lblPurchaseDate.Text = supplierProduct.PurchaseDate.ToString("dd-MM-yyyy");
                lblOtherInfo.Text = supplierProduct.OtherInformation;
                lblMaterialID.Text = supplierProduct.MaterialID.ToString();

                lnkEdit.CommandArgument = supplierProduct.SupplierProductID.ToString();
                lnkEdit.CommandName = "EditSupplierProduct";

            }
        }

        protected void lvAllSupplierList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSupplierProduct")
            {
                int supplierID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Views/SupplierUI.aspx?supplierID=" + supplierID);
            }
            else
            { }
        }

        protected void OnPagePropertyChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvAllSupplierList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadSupplierProductList();
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierUI.aspx");
        }
    }
}