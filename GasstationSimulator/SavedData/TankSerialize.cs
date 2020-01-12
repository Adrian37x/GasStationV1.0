using GasstationSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.SavedData
{
    public class TankSerialize
    {
        public GasType gasType;
        public float minLiterAmount;
        public float literAmount;

        public TankSerialize(Tank tank)
        {
            gasType = tank.GetGasType();
            minLiterAmount = tank.GetMinLiterAmount();
            literAmount = tank.GetLiterAmount();
        }
    }
}