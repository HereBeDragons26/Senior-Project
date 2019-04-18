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


            return product;

        }

    }
}