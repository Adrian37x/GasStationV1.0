using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class CashRegister
    {
        private List<Receipt> receipts;

        public List<Receipt> GetReceipts()
        {
            return receipts;
        }

        public CashRegister(List<Receipt> receipts)
        {
            this.receipts = receipts;
        }
    }
}