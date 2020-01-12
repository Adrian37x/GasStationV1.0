using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public static class Context
    {
        private static GasStation gasStation;   // static gas station to access it from every view or controller

        #region get set methods
        public static GasStation GetGasStation()
        {
            return gasStation;
        }
        #endregion

        // creates gas station
        static Context()
        {
            // create coin type array and sort them by their value desc
            float[] coinTypes = { 0.05f, 0.1f, 0.2f, 0.5f, 1f, 2f, 5f, 10f, 20f, 50f, 100f };
            Array.Sort(coinTypes);
            Array.Reverse(coinTypes);

            // create cash registers
            CashRegister[] cashRegisters = {
                new CashRegister(coinTypes),
                new CashRegister(coinTypes)
            };

            // create empty array
            Gas[] gases = new Gas[0];

            // read tanks out of file
            Tank[] tanks = Serialize.ReadTanks();

            // if there is saved tank data
            if (tanks.Length > 0)
            {
                gases = new Gas[] {
                    new Gas(GasType.Bleifrei95, 1.59f, tanks.Where(t => t.GetGasType() == GasType.Bleifrei95).ToArray()),
                    new Gas(GasType.Super98, 1.62f, tanks.Where(t => t.GetGasType() == GasType.Super98).ToArray()),
                    new Gas(GasType.Diesel, 1.77f, tanks.Where(t => t.GetGasType() == GasType.Diesel).ToArray())
                };
            }
            else
            {
                // create different gas with tanks
                gases = new Gas[] {
                    new Gas(GasType.Bleifrei95, 1.59f, new Tank[]{
                        new Tank(GasType.Bleifrei95, 200, 1000),
                        new Tank(GasType.Bleifrei95, 200, 500),
                    }),
                    new Gas(GasType.Super98, 1.62f, new Tank[] {
                        new Tank(GasType.Super98, 200, 1000),
                        new Tank(GasType.Super98, 200, 500),
                    }),
                    new Gas(GasType.Diesel, 1.77f, new Tank[] {
                        new Tank(GasType.Diesel, 200, 1000),
                        new Tank(GasType.Diesel, 200, 500),
                    })
                };
            }

            // create gas pumps with taps
            List<GasPump> gasPumpsTemp = new List<GasPump>();
            for (int i = 0; i < 4; i++)
            {
                List<Tap> taps = new List<Tap>();
                for (int t = 0; t < gases.Length; t++)
                {
                    Tap tap = new Tap(gases[t]);
                    taps.Add(tap);
                }

                gasPumpsTemp.Add(new GasPump(taps.ToArray()));
            }
            GasPump[] gasPumps = gasPumpsTemp.ToArray();

            // create gas station with the gas pumps and cash registers which were created earlier
            gasStation = new GasStation("Migrolino", gasPumps, cashRegisters);
        }
    }
}