using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain.Model {
    public class Feature {

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Feature(DateTime date, string description) {
            Date = date;
            Description = description;
        }
    }
}