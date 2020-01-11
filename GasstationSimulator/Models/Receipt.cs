using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    [Serializable]
    public class Receipt
    {
        private GasType gasType;        // gas type info
        private float fueledLiter;      // fueled liter info
        private float paymentAmount;    // payment amount info
        private DateTime timeStamp;     // time stamp of creation

        #region get set methods
        public GasType GetGasType()
        {
            return gasType;
        }

        public float GetFueledLiter()
        {
            return fueledLiter;
        }

        public float GetPaymentAmount()
        {
            // rounded to 0.05 step (42.23 -> 42.25)
            return (float)Math.Round(paymentAmount * 20) / 20;
        }

        public DateTime GetTimeStamp()
        {
            return timeStamp;
        }
        #endregion

        public Receipt(GasType gasType, float fueledLiter, float paymentAmount, DateTime timeStamp)
        {
            this.gasType = gasType;
            this.fueledLiter = fueledLiter;
            this.paymentAmount = paymentAmount;
            this.timeStamp = timeStamp;
        }
    }
}