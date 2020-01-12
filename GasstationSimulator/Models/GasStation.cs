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

            AjustMinLiterAmount();
        }

        // Ajusts the minLiterAmount in every tank of each gas type
        // by the liter revenue of the corresponding month of the last year
        private void AjustMinLiterAmount()
        {
            // get all tanks
            List<Tank> tanks = new List<Tank>();
            if (gasPumps.Length > 0)
            {
                foreach (Tap tap in gasPumps[0].GetTaps())
                {
                    foreach (Tank tank in tap.GetGas().GetTanks())
                    {
                        tanks.Add(tank);
                    }
                }
            }

            foreach (Tank tank in tanks)
            {
                // get month revenue of last year
                float revenue = CalcRevenueOfLastYearByMonthByGasType(DateTime.Now.Month, tank.GetGasType());

                int basicAmount = 200; // could be any basic amount (like a backup amount)
                int factor = 10; // could be any factor
                tank.SetMinLiterAmount(basicAmount + revenue / factor);
            }

            // save new tanks
            Serialize.SaveTanks(tanks.ToArray());
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

        // Calculate revenue of last year by month by gas type
        public float CalcRevenueOfLastYearByMonthByGasType(int month, GasType gasType)
        {
            float total = 0;
            Receipt[] receipts = Serialize.ReadReceipts();
            foreach (Receipt receipt in receipts)
            {
                if (receipt.GetTimeStamp().Year == DateTime.Now.AddYears(-1).Year
                    && receipt.GetTimeStamp().Month == month
                    && receipt.GetGasType() == gasType)
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