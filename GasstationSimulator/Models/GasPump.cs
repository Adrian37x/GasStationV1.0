using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class GasPump
    {
        private Tap[] taps;                 // taps of that gas pump
        private bool isActive;              // if is in use or not
        private GasType? selectedGasType;   // if active get selected gas type else null
        private float fueledLiter;          // amount of taken fuel in liter
        private float paymentAmount;        // cost of the fueled liter

        #region get set methods
        public Tap[] GetTaps()
        {
            return taps;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public GasType? GetSelectedGasType()
        {
            return selectedGasType;
        }

        public float GetFueledLiter()
        {
            return fueledLiter;
        }

        public float GetPaymentAmount()
        {
            // round to 0.05 step (z.B. 45.23 -> 45.25)
            return (float)Math.Round(paymentAmount * 20) / 20;
        }
        #endregion

        public GasPump(Tap[] taps)
        {
            this.taps = taps;
            this.isActive = false;
            this.fueledLiter = 0;
            this.paymentAmount = 0;
        }

        public void SelectTap(Tap selectedTap)
        {
            // set attributes to "selected" values
            selectedGasType = selectedTap.GetGas().GetGasType();
            fueledLiter = 0;
            paymentAmount = 0;
            isActive = true;

            foreach (Tap tap in taps)
            {
                // if tap is equal to selected tap set 'locked' to true else set to false
                tap.SetIsLocked(selectedTap != tap);
            }
        }

        public void Refuel(Tap selectedTap, float literToFuel)
        {
            // update fueledLiter and paymentAmount
            fueledLiter += literToFuel;
            paymentAmount += selectedTap.GetGas().GetPricePerLiter() * literToFuel;
            
            // get all tanks of tap (correct gas type) ordered by liter amount desc
            Tank[] tanskOfTap = selectedTap.GetGas().GetTanks().OrderByDescending(t => t.GetLiterAmount()).ToArray();

            for (int i = 0; i < tanskOfTap.Length; i++)
            {
                // if not full liter amount is removed
                if (literToFuel > 0)
                {
                    // if tank has more liter than needed to remove
                    if (tanskOfTap[i].GetLiterAmount() > literToFuel)
                    {
                        // remove liter amount
                        tanskOfTap[i].SetLiterAmount(tanskOfTap[i].GetLiterAmount() - literToFuel);
                        literToFuel = 0;
                    }
                    else
                    {
                        // remove as much liters out of tank as possible
                        float literAmount = tanskOfTap[i].GetLiterAmount();
                        tanskOfTap[i].SetLiterAmount(tanskOfTap[i].GetLiterAmount() - literAmount);

                        // dicrease liter amount to remove
                        literToFuel -= literAmount;
                    }
                }
            }

            //Get all tanks to save all to file
            List<Tank> allTanks = new List<Tank>();
            foreach (Tap tap in taps)
            {
                Tank[] tanks = tap.GetGas().GetTanks();
                foreach (Tank tank in tanks)
                {
                    allTanks.Add(tank);
                }
            }

            // Save tanks to file
            Serialize.SaveTanks(allTanks.ToArray());
        }

        // lock all taps
        public void LockFueling()
        {
            foreach (Tap tap in taps)
            {
                tap.SetIsLocked(true);
            }
        }

        // unlock all taps
        public void UnlockFueling()
        {
            foreach (Tap tap in taps)
            {
                tap.SetIsLocked(false);
            }
        }

        // releases gas pump
        public void Clear()
        {
            isActive = false;
            selectedGasType = null;
            UnlockFueling();
        }
    }
}