using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Gas
    {
        private GasType gastype;
        private List<Tank> tanks;
        private float pricePerLiter;

        public GasType GetGasType()
        {
            return gastype;
        }

        public List<Tank> GetTanks()
        {
            return tanks;

        }

        public float GetPricePerLiter()
        {
            return pricePerLiter;
        }

        public void SetPricePerLiter(float pricePerLiter)
        {
            this.pricePerLiter = pricePerLiter;
        }

        public Gas(GasType gastype, float pricePerLiter , List<Tank> tanks)
        {
            this.gastype = gastype;
            this.pricePerLiter = pricePerLiter;
            this.tanks = tanks;
        }
    }
}