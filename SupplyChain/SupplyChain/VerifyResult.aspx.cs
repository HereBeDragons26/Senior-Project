using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain
{
    public partial class VerifyResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack) return;

            String id = Request.QueryString["id"];


            Product product = verifyId(id);

            printProductInTable(product);

        }


        protected void printProductInTable(Product product)
        {

            product.features.Sort((f1, f2) => f1.date.CompareTo(f2.date) );

            product.features.ForEach(p =>
            {
                TableRow r = new TableRow();

                TableCell c1 = new TableCell();
                c1.Controls.Add(new LiteralControl(p.date.ToString("dd/MM/yyyy")));
                r.Cells.Add(c1);

                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(p.description));
                r.Cells.Add(c2);

                VerifyResultTable.Rows.Add(r);
            });

        }

        Product verifyId(String id)
        {
            Product product = new Product();

            /*
             * Here it talks with blockchain.
             * Generates a product.
             * Return it.
             */

            /*** Test ***/

            Feature feature;

            feature = new Feature(new DateTime(2019, 04, 15), "Recieved by the market");
            product.features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 10), "Milked from cow 1250193");
            product.features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 13), "Boxed");
            product.features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 12), "Pastorized");
            product.features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 11), "Shipped to the factory");
            product.features.Add(feature);

            feature = new Feature(new DateTime(2019, 04, 14), "Sent to the market");
            product.features.Add(feature);

            /***      ***/


            return product;

        }

    }
}