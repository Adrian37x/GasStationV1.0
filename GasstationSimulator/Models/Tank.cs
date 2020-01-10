using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Tank
    {
        private GasType gasType;        // gas type of tank gas
        private float minLiterAmount;   // critical fuel amount limit
        private float literAmount;      // current liter stand

        #region get set methods
        public GasType GetGasType()
        {
            return gasType;
        }

        public float GetMinLiterAmount()
        {
            return minLiterAmount;
        }

        public float GetLiterAmount()
        {
            return literAmount;
        }

        public void SetLiterAmount(float literAmount)
        {
            this.literAmount = literAmount;
        }
        #endregion

        public Tank(GasType gasType, float minLiterAmount, float literAmount)
        {
            this.gasType = gasType;
            this.minLiterAmount = minLiterAmount;
            this.literAmount = literAmount;
        }
    }
}