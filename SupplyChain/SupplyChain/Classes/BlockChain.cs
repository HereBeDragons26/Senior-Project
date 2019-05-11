using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain.Classes {
    public class BlockChain {
        private static List<Block> Chain = null;
        public static List<string> minerIPs = new List<string>();

        private BlockChain() {
            GetChain();
        }
        public static List<Block> GetChain() {
            if(Chain == null) {
                Chain = new List<Block>();
            }
            return Chain;
        }


    }
}