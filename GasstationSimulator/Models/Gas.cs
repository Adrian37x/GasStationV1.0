using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Gas
    {
        private GasType gastype;        // which type of gas
        private Tank[] tanks;           // tanks with this gas type
        private float pricePerLiter;    // how much cost per liter

        #region get set methods
        public GasType GetGasType()
        {
            return gastype;
        }

        public Tank[] GetTanks()
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
        #endregion

        public Gas(GasType gastype, float pricePerLiter , Tank[] tanks)
        {
            this.gastype = gastype;
            this.pricePerLiter = pricePerLiter;
            this.tanks = tanks;
        }
    }
}