using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public static class Serialize
    {
        public static Tank[] ReadTanks()
        {
            // %TODO%
            // read out of Tanks.txt file
            // read and save as JSON!!!

            return new Tank[0];
        }

        public static Receipt[] ReadReceipts()
        {
            // %TODO%
            // read out of Receipts.txt file
            // read and save as JSON!!!

            return new Receipt[0];
        }

        public static void SaveTanks(Tank[] tanks)
        {
            // %TODO%
            // write all tanks in Tank.txt file
            // replace content!!!
            // read and save as JSON!!!
        }

        public static void SaveReceipt(Receipt receipt)
        {
            // %TODO%
            // write receipt in Receipt.txt file
            // append at the end of content or 
            // read first add new receipt and replace new with old
            // read and save as JSON!!!
        }
    }
}