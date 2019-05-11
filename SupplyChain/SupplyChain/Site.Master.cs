using SupplyChain.Classes;
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

            if (!IsPostBack) {
                TCP.StartListener();
            }

            // in case, there have been logged in
            if (Request.Cookies["UserIdentity"] != null)
            {
                ControlVisibilty("in");

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

            // login is failed
            if (dv == null || dv.Table.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key1", "unsuccessLogin();", true);
                return;
            }

            /*** login is successful ***/

            // Create a cookie to recognize the user later
            HttpCookie cookieUserIdentity = new HttpCookie("UserIdentity");
            cookieUserIdentity["email"] = UserNameTextBox.Text;
            cookieUserIdentity["password"] = PasswordTextBox.Text;
            cookieUserIdentity.Expires = DateTime.Now.AddDays(7); // 1 week expire date
            Response.Cookies.Add(cookieUserIdentity);

            // switch the visibilty of buttons
            ControlVisibilty("in");

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {

            // Delete the cookie
            HttpCookie cookieUserIdentity = new HttpCookie("UserIdentity");
            cookieUserIdentity.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookieUserIdentity);

            // switch the visibilty of buttons
            ControlVisibilty("out");

            // after logout redirect to the mainpage
            Response.Redirect("MainPage.aspx");

        }

        protected void ProductInfoRedirectButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductInfoPage.aspx");
        }

        protected void ControlVisibilty(String LogStatus)
        {

            if (LogStatus == "in")
            {
                LoginPopupButton.Visible = false;
                LogoutButton.Visible = true;
                ProductInfoRedirectButton.Visible = true;
                WelcomeNavLabel.InnerText = "Welcome, " + Request.Cookies["UserIdentity"]["email"];

                return;
            }

            if(LogStatus == "out")
            {
                LoginPopupButton.Visible = true;
                LogoutButton.Visible = false;
                ProductInfoRedirectButton.Visible = false;
                WelcomeNavLabel.InnerText = ""; // leave it empty
            }

        }
    }
}