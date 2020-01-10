using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Tap
    {
        private Gas gas;
        private bool isLocked;

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

        public Tap(Gas gas)
        {
            this.gas = gas;
            this.isLocked = false;
        }
    }
}