using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain.Blockchain {
    public class Blockchain {
        private static List<Block> Chain = null;
        private static long genesisBlockID = 12589;

        private Blockchain() {
            GetChain();
        }
        public static List<Block> GetChain() {
            if(Chain == null) {
                Chain = new List<Block>();
                Chain.Add(CreateGenesisBlock());
            }
            return Chain;
        }

        public static Block CreateGenesisBlock() {
            return new Block(new List<long>(), genesisBlockID, new Product(), "0");
        }

        public static Block CreateBlock(List<long> parentID, Product product) {
            List<Block> chain = GetChain();
            Block lastBlock = chain[chain.Count - 1];
            String lastBlockHash = lastBlock.Hash;
            long lastBlockID = lastBlock.BlockID + 1;
            return new Block(parentID, lastBlockID, product, lastBlockHash);
        }

        public static Block GetBlock(long blockID) {
            return Chain[(int)(blockID - genesisBlockID)];
        }

        //public static List<Block> GetAllBlock(long blockID) {
        //    List<Block> blocks = new List<Block>();
        //    for (int a = 0; a < GetBlock(blockID).ParentID.Count; a++) {
        //        blocks.Add(GetBlock()
        //    }
        //}
    }
}