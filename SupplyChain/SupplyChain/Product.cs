using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain
{
    public class Product
    {
        public List<Feature> features {  get; }

        public Product()
        {
            features = new List<Feature>();
        }

    }
}