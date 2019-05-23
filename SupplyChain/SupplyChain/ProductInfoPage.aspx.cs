using SupplyChain.Classes;
using SupplyChain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyChain {
    public partial class ProductInfoPage : System.Web.UI.Page {

        static Product currentProduct;
        static List<long> parents;
        public static bool waitBlockID;
        public static string lastBlockID;

        protected void Page_Load(object sender, EventArgs e) {
                    
            // in case, no logged in
            if (Request.Cookies["UserIdentity"] == null) {
                // Always redirect to the mainpage
                Response.Redirect("MainPage.aspx");

                return;
            } 
            
            if (!IsPostBack) {
                currentProduct = new Product();
                parents = new List<long>();
                DateInput.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        protected void NewInfoButton_Click(object sender, EventArgs e) {
            Feature feature;

            feature = new Feature(Convert.ToDateTime(DateInput.Text), DescriptionTextBox.Text);
            currentProduct.Features.Add(feature);

            /*
             * Each time page is loaded, table gets reset.
             * So, print table each time.
             */

            PrintProductInAddedInfosTable(currentProduct);
            PrintParentsInAddedParentsTable(parents);
        }

        protected void AddParentId_Click(object sender, EventArgs e) {


            try{
                parents.Add(long.Parse(ProductParentIdInput.Text));
            }
            catch(System.FormatException) {

            }

            PrintProductInAddedInfosTable(currentProduct);
            PrintParentsInAddedParentsTable(parents);
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {

            /*
             *  Here the current product is sent to the blockchain
             */
            var value="Test Author";
            if (Request.Cookies["UserIdentity"]["name"] != null) {
                 value = Request.Cookies["UserIdentity"]["name"];
            }
            Data data = new Data {
                ParentID = parents,
                Product = currentProduct,
                Author = value
            };

            TCP.SendAllMiners("addBlock" + TCP.JsonSerialize(data));

            /** Reset Table **/

            currentProduct = new Product();
            parents = new List<long>();

            PrintProductInAddedInfosTable(currentProduct);
            PrintParentsInAddedParentsTable(parents);

            /** Wait until block id recieved from miners **/
            waitBlockID = true;
            while(waitBlockID);

            // print blockID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key1", "alert( 'BlockID: " + lastBlockID + "')", true);

        }

        protected void PrintProductInAddedInfosTable(Product product) {

            product.Features.Sort((f1, f2) => f1.Date.CompareTo(f2.Date));

            product.Features.ForEach(p => {
                TableRow r = new TableRow();

                /*
                 * If a new cell is added, it comes here.
                 */

                TableCell c1 = new TableCell();
                c1.Controls.Add(new LiteralControl(p.Date.ToString("dd/MM/yyyy")));

                r.Cells.Add(c1);

                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(p.Description));
                r.Cells.Add(c2);

                AddedInfosTable.Rows.Add(r);
            });

        }

        protected void PrintParentsInAddedParentsTable(List<long> parents) {
            parents.ForEach(p => {
                TableRow r = new TableRow();

                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(p.ToString()));
                r.Cells.Add(c);

                AddedParentsTable.Rows.Add(r);
            });
        }

    }
}