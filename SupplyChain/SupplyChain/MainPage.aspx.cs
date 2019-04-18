using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class MainPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void VerifyButtonClick(object sender, EventArgs e) {

            String id = ProductIdTextbox.Text;

            Response.Redirect("VerifyResult.aspx?id=" + id);

        }
    }
}