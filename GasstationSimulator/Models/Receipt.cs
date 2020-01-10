using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Receipt
    {
        private float gasAmount;
        private float price;
        private GasType gasType;
        private DateTime date;
        private CashRegister cashRegister;

        public float GetGasAmount()
        {
            return this.gasAmount;
        }

        public float GetPrice()
        {
            return this.price;
        }

        public GasType GetGasType()
        {
            return this.gasType;
        }

        public DateTime GetDate()
        {
            return this.date;
        }

        public CashRegister GetCashRegister()
        {
            return this.cashRegister;
        }
    }
}