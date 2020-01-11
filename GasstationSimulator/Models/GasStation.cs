using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class GasStation
    {
        private string companyName;             // name of the gas station company
        private GasPump[] gasPumps;             // gas pumps of the gas station
        private CashRegister[] cashRegisters;   // cash registers of the gas station

        #region get set methods
        public string GetCompanyName()
        {
            return companyName;
        }

        public GasPump[] GetGasPumps()
        {
            return gasPumps;
        }

        public CashRegister[] GetCashRegisters()
        {
            return cashRegisters;
        }
        #endregion

        public GasStation(string companyName, GasPump[] gasPumps, CashRegister[] cashRegisters)
        {
            this.companyName = companyName;
            this.gasPumps = gasPumps;
            this.cashRegisters = cashRegisters;
        }

        //Calculate revenue of last year
        public float CalcRevenueOfLastYear()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().AddYears(-1).Year == DateTime.Now.Year)
                {
                    total = total + receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        //Calculate revenue of last month
        public float CalcRevenueOfLastMonth()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().AddMonths(-1).Month == DateTime.Now.Month)
                {
                    total = total + receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        //Calculate revenue of last day
        public float CalcRevenueOfLastDay()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().AddDays(-1).Day == DateTime.Now.Day)
                {
                    total = total + receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        // %TODO%
        // and what else you need...
    }
}