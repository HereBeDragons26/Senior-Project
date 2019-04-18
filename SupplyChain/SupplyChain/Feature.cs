using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain
{
    public class Feature
    {

        public DateTime date;
        public String description;

        public Feature(DateTime date, String description)
        {
            this.date = date;
            this.description = description;
        }

    }
}