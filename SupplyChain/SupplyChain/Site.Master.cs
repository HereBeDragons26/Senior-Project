using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

            // in case, there have been logged in
            if (Request.Cookies["UserIdentity"] != null)
            {
                LoginPopupButton.Visible = false;
                LogoutButton.Visible = true;

                return;
            }

        }

        protected void LoginButton_Click(object sender, EventArgs e) {

            /*
             * Here it talks with database.
             * Return a boolean indicates whether login successful or not.
             */

            // LoginDataSource ask to the database for given password and email
            // if they are matched, then dv has the user
            DataView dv = (DataView) LoginDataSource.Select(DataSourceSelectArguments.Empty);

            if(dv.Table.Rows.Count == 0) return; // login is failed

            /*** login is successful ***/

            // switch the visibilty of buttons
            LoginPopupButton.Visible = false;
            LogoutButton.Visible = true;
            
            // Create a cookie to recognize the user later
            HttpCookie cookieUserIdentity = new HttpCookie("UserIdentity");
            cookieUserIdentity["email"] = UserNameTextBox.Text;
            cookieUserIdentity["password"] = PasswordTextBox.Text;
            cookieUserIdentity.Expires = DateTime.Now.AddDays(7); // 1 week expire date
            Response.Cookies.Add(cookieUserIdentity);

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {

            // Delete the cookie
            HttpCookie cookieUserIdentity = new HttpCookie("UserIdentity");
            cookieUserIdentity.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookieUserIdentity);

            // switch the visibilty of buttons
            LoginPopupButton.Visible = true;
            LogoutButton.Visible = false;

            // after logout redirect to the mainpage
            Response.Redirect("MainPage.aspx");

        }
    }
}