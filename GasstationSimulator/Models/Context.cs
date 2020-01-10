using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public static class Context
    {
        private static GasStation gasStation;   // static gas station to access it from every view or controller

        public static GasStation GetGasStation()
        {
            return gasStation;
        }

        // creates gas station
        static Context()
        {
            // create coin type array and sort them by their value desc
            float[] coinTypes = { 0.05f, 0.1f, 0.2f, 0.5f, 1f, 2f, 5f, 10f, 20f, 50f, 100f };
            Array.Sort<float>(coinTypes);
            Array.Reverse(coinTypes);

            // create cash registers
            CashRegister[] cashRegisters = {
                new CashRegister(coinTypes),
                new CashRegister(coinTypes)
            };

            // %TODO%
            // Serialize.ReadTanks() or create new as below
            // if (Serialize.ReadTanks().Length > 0) { ... } else { create new as below }

            // create different gas with tanks
            Gas[] gases = {
                new Gas(GasType.Bleifrei95, 1.59f, new Tank[]{
                    new Tank(GasType.Bleifrei95, 200, 1000),
                    new Tank(GasType.Bleifrei95, 200, 500),
                }),
                new Gas(GasType.Super98, 1.62f, new Tank[] {
                    new Tank(GasType.Bleifrei95, 200, 1000),
                    new Tank(GasType.Bleifrei95, 200, 500),
                }),
                new Gas(GasType.Diesel, 1.77f, new Tank[] {
                    new Tank(GasType.Bleifrei95, 200, 1000),
                    new Tank(GasType.Bleifrei95, 200, 500),
                })
            };

            // create gas pumps with taps
            List<GasPump> gasPumpsTemp = new List<GasPump>();
            for (int i = 0; i < 4; i++)
            {
                List<Tap> taps = new List<Tap>();
                for (int t = 0; t < 3; t++)
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