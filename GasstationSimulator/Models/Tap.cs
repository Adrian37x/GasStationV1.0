using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Tap
    {
        private Gas gas;        // gas of tap
        private bool isLocked;  // possible to refuel or not

        #region get set methods
        public Gas GetGas()
        {
            return gas;
        }

        public bool GetIsLocked()
        {
            return isLocked;
        }

        public void SetIsLocked(bool isLocked)
        {
            this.isLocked = isLocked;
        }
        #endregion

        public Tap(Gas gas)
        {
            this.gas = gas;
            this.isLocked = false;
        }
    }
}