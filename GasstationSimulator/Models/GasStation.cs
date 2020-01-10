using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class GasStation
    {
        private string companyName;
        private List<GasPump> gasPumps;
        private List<CashRegister> cashRegisters;

        public string GetCompanyName()
        {
            return companyName;
        }

        public List<GasPump> GetGasPumps()
        {
            return gasPumps;
        }

        public List<CashRegister> GetCashRegisters()
        {
            return cashRegisters;
        }

        public GasStation(string companyName, List<GasPump> gasPumps, List<CashRegister> cashRegisters)
        {
            this.companyName = companyName;
            this.gasPumps = gasPumps;
            this.cashRegisters = cashRegisters;
        }
    }
}