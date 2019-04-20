using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class ProductInfoPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            // in case, no logged in
            if (Request.Cookies["UserIdentity"] == null)
            {
                // Always redirect to the mainpage
                Response.Redirect("MainPage.aspx");
            }

        }
    }
}