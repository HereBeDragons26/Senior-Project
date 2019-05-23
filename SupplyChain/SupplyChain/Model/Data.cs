using SupplyChain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplyChain.Model {
    public class Data {

        public List<long> ParentID { set; get; }
        public Product Product { set; get; }
        public string Author { set; get; }

        public Data() {
            ParentID = new List<long>();
            Product = new Product();
        }

        public override string ToString() {
            string ret = "Parents: ";
            ParentID.ForEach(l => ret = ret + l + " - ");
            ret = ret + "\n";
            Product.Features.ForEach(f => ret = ret + f.Description + " - " + f.Date + "\n");
            ret = ret + "Author: " + Author;
            return ret;
        }

    }
}
