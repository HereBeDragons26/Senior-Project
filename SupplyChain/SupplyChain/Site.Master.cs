using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

            // in case, there have been logged in
            if(Session["username"] != null)
            {
                LoginPopupButton.Visible = false;
                LogoutButton.Visible = true;
            }

        }

        protected void LoginButton_Click(object sender, EventArgs e) {

            bool isLoginSuccess = true;

            /*
             * Here it talks with database.
             * Return a boolean indicates whether login successful or not.
             */

            if (!isLoginSuccess) return; // login is failed

            /*** login is successful ***/

            LoginPopupButton.Visible = false;
            LogoutButton.Visible = true;

            Session["username"] = UserNameTextBox.Text;


        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            LoginPopupButton.Visible = true;
            LogoutButton.Visible = false;

            // after logout redirect to the mainpage
            Response.Redirect("MainPage.aspx");

        }
    }
}