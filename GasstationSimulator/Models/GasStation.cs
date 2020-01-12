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

        // Calculate revenue of last year
        public float CalcRevenueOfLastYear()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().Year == DateTime.Now.AddYears(-1).Year)
                {
                    total += receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        // Calculate revenue of last month
        public float CalcRevenueOfLastMonth()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().Month == DateTime.Now.AddMonths(-1).Month)
                {
                    total += receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        // Calculate revenue of last week
        public float CalcRevenueOfLastWeek()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();

            int daysToWeekBegin = +1 - (DateTime.Now.DayOfWeek == 0 ? 7 : (int)DateTime.Now.DayOfWeek);
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().Date < DateTime.Now.AddDays(daysToWeekBegin).Date
                    && receipt.GetTimeStamp().Date >= DateTime.Now.AddDays(daysToWeekBegin -7).Date)
                {
                    total += receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        // Calculate revenue of today
        public float CalcMoneyRevenueOfToday()
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().Day == DateTime.Now.Day)
                {
                    total += receipt.GetPaymentAmount();
                }
            }
            return total;
        }

        // Calculate
        public float CalcLiterRevenueOfToday(GasType gasType)
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts.Where(r => r.GetGasType() == gasType))
            {
                if (receipt.GetTimeStamp().Day == DateTime.Now.Day)
                {
                    total += receipt.GetFueledLiter();
                }
            }
            return total;
        }
    }
}