using SupplyChain.Classes;
using SupplyChain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class VerifyResult : System.Web.UI.Page {

        public static VerifyResult verifyResultPageInstance;
        public volatile Boolean finish;

        protected void Page_Load(object sender, EventArgs e) {

            if (IsPostBack) return;

            String id = Request.QueryString["id"];

            verifyResultPageInstance = this;

            TCP.Send(TCP.minerIPs[0], "verify" + id);

            while (!finish) ;

        }


        public void printProductInTable(Product product) {

            product.Features.Sort((f1, f2) => f1.Date.CompareTo(f2.Date));

            product.Features.ForEach(p => {
                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Controls.Add(new LiteralControl(p.Date.ToString("dd/MM/yyyy")));
                r.Cells.Add(c1);

                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(p.Description));
                r.Cells.Add(c2);

                VerifyResultTable.Rows.Add(r);
            });

        }

    }
}