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
    public partial class DressTypeUI : System.Web.UI.Page
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        List<DressType> listofDressType;
        string Savemsg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserName"] != null))
            {
                lblUserName.Visible = true;
                lblUserName.Text = "Welcome " + Session["UserName"].ToString();
                LoadDressTypeListview();
            }
        }

        private void LoadDressTypeListview()
        {
            listofDressType = new List<DressType>();
            listofDressType = tailorBLL.GetAllDressType();
            if (listofDressType.Count>0)
            {
                lvAllDressType.DataSource = listofDressType;
                lvAllDressType.DataBind();
            }
            else
            {
                lvAllDressType.DataSource = null; ;
                lvAllDressType.DataBind();
            }
            
        }

        protected void btnSaveDress_Click(object sender, EventArgs e)
        {
            DressType aDressType = new DressType();
            aDressType.TypeName = txtDressType.Text;
            aDressType.DressPrice = Convert.ToDouble(txtDressPrice.Text);

            if (btnSaveDress.Text == "Update")
            {
                int DressTypeID = Convert.ToInt32(lbldresstypeIDhidden.Text);
                Savemsg = tailorBLL.UpdateDressType(aDressType, DressTypeID);
                btnSaveDress.Text = "Save";
                listViewRowNo = 0;
            }
            else
            {
                Savemsg = tailorBLL.SaveDressType(aDressType);
                listViewRowNo = 0;
            }
            System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
            strbuilder.Append("<script type = 'text/javascript'>");
            strbuilder.Append("window.onload=function(){");
            strbuilder.Append("alert('");
            strbuilder.Append(Savemsg);
            strbuilder.Append("')};");
            strbuilder.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", strbuilder.ToString());
            ClearAllField();
            LoadDressTypeListview();
        }

        private void ClearAllField()
        {
            txtDressPrice.Text = string.Empty;
            txtDressType.Text = string.Empty;
        }

        int listViewRowNo = 0;
        protected void lvAllDressType_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                DressType dressType = (DressType)((ListViewDataItem)(e.Item)).DataItem;

                Label lblDressType = (Label)currentItem.FindControl("lblDressType");
                Label lblDressPrice = (Label)currentItem.FindControl("lblDressPrice");

                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");

                //listViewRowNo = 0;
                listViewRowNo += 1;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = listViewRowNo.ToString();

                lblDressType.Text = dressType.TypeName;
                lblDressPrice.Text = dressType.DressPrice.ToString();

                lnkEdit.CommandArgument = dressType.DressTypeID.ToString();
                lnkEdit.CommandName = "EditDressType";


            }
        }

        protected void lvAllDressType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDressType")
            {
                int dressTypeID = Convert.ToInt32(e.CommandArgument);
                lbldresstypeIDhidden.Text = dressTypeID.ToString();
                listofDressType = new List<DressType>();
                listofDressType = tailorBLL.GetAllDressTypeByID(dressTypeID);
                foreach (var item in listofDressType)
                {
                    txtDressType.Text = item.TypeName.ToString();
                    txtDressPrice.Text = item.DressPrice.ToString();
                    btnSaveDress.Text = "Update";
                }
            }
            else
            {

            }
        }

        //int CurrentPage = 0;
        protected void OnPagePropertyChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvAllDressType.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadDressTypeListview();
            //CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
    }
}