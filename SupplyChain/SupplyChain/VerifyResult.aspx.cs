using SupplyChain.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class VerifyResult : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (IsPostBack) return;

            String id = Request.QueryString["id"];


            Product product = VerifyId(id);

            printProductInTable(product);

        }


        protected void printProductInTable(Product product) {

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

        Product VerifyId(string id) {

            List<Block> blocks = new List<Block>();
            while(true) {
                blocks.Add(Blockchain.Blockchain.GetBlock(int.Parse(id)));

            }

            Product product = new Product();

            /*
             * Here it talks with blockchain.
             * Generates a product.
             * Return it.
             */

            /*** Test ***/

            Feature feature;

            feature = new Feature(new DateTime(2019, 04, 15), "Recieved by the market");
            product.Features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 10), "Milked from cow 1250193");
            product.Features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 13), "Boxed");
            product.Features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 12), "Pastorized");
            product.Features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 11), "Shipped to the factory");
            product.Features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 14), "Sent to the market");
            product.Features.Add(feature);

            /***      ***/


            return product;

        }


    }
}