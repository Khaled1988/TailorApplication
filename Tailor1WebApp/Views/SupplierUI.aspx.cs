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
    public partial class SupplierUI : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        int supplierID = 0;
        string SupplierCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSupplierCode();
                if ((Session["UserName"] != null))
                {
                    lblUserName.Visible = true;
                    lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                }
                supplierID = Convert.ToInt32(Request["supplierID"]);
                if (supplierID > 0)
                {
                    //lblMeasurementHiddenID.Text = measurementID.ToString();
                    List<Supplier> listofSuppliers = new List<Supplier>();
                    List<Material> materialList = new List<Material>();
                    listofSuppliers = tailorBLL.GetAllSupplierBySupplierID(supplierID);
                    foreach (var aSupplier in listofSuppliers)
                    {
                        txtSupplierCode.Text = aSupplier.SupplierCode;
                        SupplierCode = txtSupplierCode.Text;
                        txtSupplierName.Text = aSupplier.SupplierName;
                        txtSupplierAddress.Text = aSupplier.SupplierAddress;
                        txtSupplierMobile.Text = aSupplier.SupplierMobile;

                        materialList = tailorBLL.GetAllMaterialBySupplierID(supplierID);

                        foreach (var aMaterial in materialList)
                        {
                            txtMaterialName.Text = aMaterial.MaterialName;
                            txtMaterialPrice.Text = aMaterial.MaterialPrice.ToString();
                            txtQuantity.Text = aMaterial.MaterialQuantity.ToString();

                            //ddlMeasurementUnit.SelectedItem.Text = aMaterial.Unit.ToString();
                            ddlMeasurementUnit.SelectedValue = aMaterial.Unit;

                            txtMaterialCode.Text = aMaterial.MaterialCode;
                            txtPurchaseDate.Text = aMaterial.PurchaseDate.ToShortDateString();
                            txtOtherSupplierInfo.Text = aMaterial.MaterialOtherInfo;
                            lblMaterialIDHidden.Text = aMaterial.MaterialID.ToString();
                        }

                    }
                    btnSupplierSave.Text = "Update";
                    btnCancel.Visible = true;
                }
            }
        }
        private void LoadSupplierCode()
        {
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = tailorBLL.GetAllSupplier();
            if (suppliers.Count > 0)
            {
                int counter = tailorBLL.GetMaxSupplierID();
                txtSupplierCode.Enabled = false;
                txtSupplierCode.Text = "Supplier-" + (counter + 1).ToString().PadLeft(5, '0');
            }
            else
            {
                int counter = 0;
                txtSupplierCode.Enabled = false;
                txtSupplierCode.Text = "Supplier-" + (counter + 1).ToString().PadLeft(5, '0');
            }
        }
        protected void btnSupplierSave_Click(object sender, EventArgs e)
        {
            //int unitId = Convert.ToInt32(ddlMeasurementUnit.SelectedValue);
            //if (unitId > 0)
            //{
                if (txtPurchaseDate.Text != "")
                {
                    Supplier aSupplier = new Supplier();
                    aSupplier.SupplierCode = txtSupplierCode.Text;
                    aSupplier.SupplierName = txtSupplierName.Text;
                    aSupplier.SupplierMobile = txtSupplierMobile.Text;
                    aSupplier.SupplierAddress = txtSupplierAddress.Text;

                    Material aMaterial = new Material();
                    aMaterial.MaterialCode = txtMaterialCode.Text;
                    aMaterial.MaterialName = txtMaterialName.Text;
                    aMaterial.MaterialOtherInfo = txtOtherSupplierInfo.Text;
                    aMaterial.MaterialPrice = Convert.ToDouble(txtMaterialPrice.Text);
                    aMaterial.MaterialQuantity = Convert.ToDouble(txtQuantity.Text);
                    aMaterial.Unit = ddlMeasurementUnit.SelectedValue;
                    aMaterial.PurchaseDate = Convert.ToDateTime(txtPurchaseDate.Text);



                    if (btnSupplierSave.Text == "Update")
                    {
                        aSupplier.SupplierID = supplierID;
                        if (ddlMeasurementUnit.SelectedValue == "sl1")
                        {
                            System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                            strbuilder.Append("<script type = 'text/javascript'>");
                            strbuilder.Append("window.onload=function(){");
                            strbuilder.Append("alert('");
                            strbuilder.Append("Select Quantity Unit");
                            strbuilder.Append("')};");
                            strbuilder.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                        }
                        else
                        {
                            string Suppliermsg = tailorBLL.UpdateSupplier(aSupplier, SupplierCode);

                            aMaterial.SupplierID = supplierID;
                            string Materialmsg = tailorBLL.UpdateProduct(aMaterial, supplierID);

                            string combineMessage = "Supplier and Accessories Updated Successfully";
                            System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                            strbuilder.Append("<script type = 'text/javascript'>");
                            strbuilder.Append("window.onload=function(){");
                            strbuilder.Append("alert('");
                            strbuilder.Append(combineMessage);
                            strbuilder.Append("')};");
                            strbuilder.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                        }

                    }
                    else
                    {
                        if (ddlMeasurementUnit.SelectedValue == "sl1")
                        {
                            System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                            strbuilder.Append("<script type = 'text/javascript'>");
                            strbuilder.Append("window.onload=function(){");
                            strbuilder.Append("alert('");
                            strbuilder.Append("Select Quantity Unit");
                            strbuilder.Append("')};");
                            strbuilder.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                        }
                        else
                        {
                            string Suppliermsg = tailorBLL.SaveSupplier(aSupplier);
                            int SupplierID = tailorBLL.GetSupplierIDBySupplierCode(txtSupplierCode.Text);

                            aMaterial.SupplierID = SupplierID;
                            string Materialmsg = tailorBLL.SaveMaterial(aMaterial);

                            string combineMessage = "Supplier and Accessories Information Saved Successfully";
                            System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                            strbuilder.Append("<script type = 'text/javascript'>");
                            strbuilder.Append("window.onload=function(){");
                            strbuilder.Append("alert('");
                            strbuilder.Append(combineMessage);
                            strbuilder.Append("')};");
                            strbuilder.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
                        }

                    }

                    ClearAllField();
                }
                else
                {
                    lblMessage.Text = "Enter Purchase Date";
                    btnSupplierSave.Focus();
                }
            //}
            //else
            //{
            //    lblMessage.Text = "Select Accessories Quantity Unit";
            //    btnSupplierSave.Focus();
            //}

        }
        private void ClearAllField()
        {
            txtMaterialCode.Text = string.Empty;
            txtMaterialName.Text = string.Empty;
            txtMaterialPrice.Text = string.Empty;
            txtOtherSupplierInfo.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
            txtSupplierCode.Text = string.Empty;
            txtSupplierMobile.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            lblMessage.Text = string.Empty;
            txtPurchaseDate.Text = string.Empty;
            ddlMeasurementUnit.SelectedValue = "sl1";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierSearch.aspx");
        }
    }
}