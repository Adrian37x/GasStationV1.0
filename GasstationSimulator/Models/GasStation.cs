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

        public float CalcRevenueOfLastYear()
        {
            // %TODO%
            // Serialize.ReadReceipts()
            // and then calc algorhythm
            return 0;
        }

        public float CalcRevenueOfLastMonth()
        {
            // %TODO%
            // Serialize.ReadReceipts()
            // and then calc algorhythm
            return 0;
        }

        public float CalcRevenueOfLastDay()
        {
            // %TODO%
            // Serialize.ReadReceipts()
            // and then calc algorhythm
            return 0;
        }

        // %TODO%
        // and what else you need...
    }
}