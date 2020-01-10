using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class Tank
    {
        private float minLiterAmount;
        private float literAmount;

        public float GetMinliterAmount()
        {
            return minLiterAmount;
        }

        public void SetMinLiterAmount(float minLiterAmount)
        {
            this.minLiterAmount = minLiterAmount;
        }

        public float GetLiterAmount()
        {
            return literAmount;
        }

        public void SetLiterAmount(float literAmount)
        {
            this.literAmount = literAmount;
        }

        public Tank(float minLiterAmount, float literAmount)
        {
            this.minLiterAmount = minLiterAmount;
            this.literAmount = literAmount;
        }
    }
}