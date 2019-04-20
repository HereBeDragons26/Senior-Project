using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain.Blockchain
{
    public class Blockchain
    {
         public IList<Block> chain { get; set; }

        public Blockchain()
        {
            InitializeChain();
        }
        public void InitializeChain()
        {
            chain = new List<Block>();
        }

        public Block CreateBlock(string data,string previoushash,int index,int productID,int companyID)
        {
            return new Block(DateTime.Now, data, previoushash, index, productID, companyID);
        } 
        
    }
}