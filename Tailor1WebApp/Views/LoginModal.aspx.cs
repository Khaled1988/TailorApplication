using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tailor1WebApp.Views
{
    public partial class LoginModal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["LoginTime"] = DateTime.Now;
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            //List<User> userList = new List<User>();
            //userList = tailorBLL.GetUserInfoByUserID(txtUserID.Text);

            //foreach (var item in userList)
            //{
            //    string User = item.FullName;
            //    Session["UserName"] = User;
            //}

            //User aUser = new User();
            //aUser.LoginID = txtUserID.Text;
            //aUser.Password = txtPassword.Text;
            //string msg = tailorBLL.CheckUser(aUser.LoginID, aUser.Password);
            //if (msg == "")
            //{
            //    //Response.Redirect("CustomerSearch.aspx");
            //    Response.Redirect("AboutTailor.aspx");
            //}
            //else
            //{
            //    txtUserID.Text = string.Empty;
            //    txtPassword.Text = string.Empty;
            //    txtMessage.Text = msg.ToString();
            //}
        }

    }
}