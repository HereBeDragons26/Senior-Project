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

        public static Product currentProduct;

        protected void Page_Load(object sender, EventArgs e) {

            if (IsPostBack) return;

            String id = Request.QueryString["id"];

            verifyResultPageInstance = this;

            if(TCP.minerIPs.Count != 0) TCP.Send(TCP.minerIPs[0], "verify" + id);

            while(!finish);

            finish = false;

            printProductInTable(currentProduct);

        }


        private void printProductInTable(Product product) {

            for (int i = 1; i < VerifyResultTable.Rows.Count; i++) {
                VerifyResultTable.Rows.RemoveAt(i);
            }

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