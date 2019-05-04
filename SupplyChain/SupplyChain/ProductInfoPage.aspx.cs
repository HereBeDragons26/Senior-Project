using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class ProductInfoPage : System.Web.UI.Page {

        static Product currentProduct;

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) currentProduct = new Product();

            // in case, no logged in
            if (Request.Cookies["UserIdentity"] == null)
            {
                // Always redirect to the mainpage
                Response.Redirect("MainPage.aspx");

                return;
            }



        }

        protected void NewInfoButton_Click(object sender, EventArgs e)
        {
            Feature feature;

            feature = new Feature(Convert.ToDateTime(DateInput.Text), DescriptionTextBox.Text);
            currentProduct.features.Add(feature);

            /*
             * Each time page is loaded, table gets reset.
             * So, print table each time.
             */

            printProductInAddedInfosTable(currentProduct);

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {

            /*
             *  Here the current product is sent to the blockchain
             */

            currentProduct = new Product();

            printProductInAddedInfosTable(currentProduct);

        }

        protected void printProductInAddedInfosTable(Product product)
        {

            product.features.Sort((f1, f2) => f1.date.CompareTo(f2.date));

            product.features.ForEach(p =>
            {
                TableRow r = new TableRow();

                /*
                 * If a new cell is added, it comes here.
                 */

                TableCell c1 = new TableCell();
                c1.Controls.Add(new LiteralControl(p.date.ToString("dd/MM/yyyy")));
                r.Cells.Add(c1);

                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(p.description));
                r.Cells.Add(c2);

                AddedInfosTable.Rows.Add(r);
            });

        }

        protected void AddParentId_Click(object sender, EventArgs e)
        {

        }
    }
}