using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain {
    public class Product {
        public List<Feature> Features { get; set; }

        public Product() {
            Features = new List<Feature>();
        }
    }
}