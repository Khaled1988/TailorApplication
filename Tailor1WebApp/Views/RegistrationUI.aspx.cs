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
    public partial class RegistrationUI : System.Web.UI.Page  
    {
        TailorAppBLL tailorBLL = new TailorAppBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            aUser.LoginID = txtuserID.Text;
            aUser.Password = txtUserPassword.Text;
            aUser.FullName = txtUserFullName.Text;
            aUser.MobileNo = txtUserMobile.Text;
            string message = tailorBLL.SaveUser(aUser);
            txtMessage.Text = message.ToString();
            ClearAllFields();
            Response.Redirect("~/Views/LoginUI.aspx");
        }

        private void ClearAllFields()
        {
            txtuserID.Text = string.Empty;
            txtUserPassword.Text = string.Empty;
            txtUserFullName.Text = string.Empty;
            txtUserMobile.Text = string.Empty;
        }

        protected void btnCancil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AboutTailor.aspx");
        }
    }
}