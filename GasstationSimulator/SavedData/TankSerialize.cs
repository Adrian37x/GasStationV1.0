using GasstationSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.SavedData
{
    public class TankSerialize
    {
        public GasType gasType;        // gas type of tank gas
        public float minLiterAmount;   // critical fuel amount limit
        public float literAmount;      // current liter stand
    }
}