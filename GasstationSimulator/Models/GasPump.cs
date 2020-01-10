using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class GasPump
    {
        private List<Tap> taps;
        private bool isActive;
        private float fueledLiter;
        private float paymentAmount;
        
        public List<Tap> GetTaps()
        {
            return taps;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public void SetIsActive(bool isActive)
        {
            this.isActive = isActive;
        }

        public float GetFueledLiter()
        {
            return fueledLiter;
        }

        public void SetFueledLiter(float fueledLiter)
        {
            this.fueledLiter = fueledLiter;
        }

        public float GetPaymentAmount()
        {
            return paymentAmount;
        }

        public void SetPaymentAmount(float paymentAmount)
        {
            this.paymentAmount = paymentAmount;
        }

        public GasPump(List<Tap> taps)
        {
            this.taps = taps;
            this.isActive = false;
            this.fueledLiter = 0;
            this.paymentAmount = 0;
        }

        public void SelectTap(Tap selectedTap)
        {
            fueledLiter = 0;
            paymentAmount = 0;

            isActive = true;
            foreach (Tap tap in taps)
            {
                tap.SetIsLocked(selectedTap != tap);
            }
        }

        public void Fuel(Tap tap, float liter)
        {
            fueledLiter += liter;
            paymentAmount += tap.GetGas().GetPricePerLiter() * liter;
            // remove gas out of tanks (which tank has enough, which has to be refilled)
        }
    }
}