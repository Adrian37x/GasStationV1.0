using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;

namespace GasstationSimulator.Models
{
    public static class Context
    {
        private static GasStation gasStation;

        public static GasStation GetGasStation()
        {
            return gasStation;
        }

        static Context()
        {
            
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Serialization/initData.txt";
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Description", typeof(string)));
            table.Columns.Add(new DataColumn("Value", typeof(string)));

            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string line = "";
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] words = line.Split(':');
                        DataRow row = table.NewRow();
                        table.Rows.Add(words[0], words[1]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            //table.Rows[x].Field<string>(y) -> Zugriff auf die Tabelle
            

                List<CashRegister> cashRegisters = new List<CashRegister>();
            for (int i = 0; i < Convert.ToInt32(table.Rows[0].Field<string>(1)); i++)
            {
                // existing receipts save and read in file
                CashRegister cashRegister = new CashRegister(new List<Receipt>());
                cashRegisters.Add(cashRegister);
            }

            List<Gas> gases = new List<Gas>
            {
                new Gas(GasType.Bleifrei95, 1.59f, new List<Tank>{
                    new Tank(100, 1000),
                    new Tank(100, 500),
                }),
                new Gas(GasType.Super98, 1.62f, new List<Tank>{
                    new Tank(100, 1000),
                    new Tank(100, 500),
                }),
                new Gas(GasType.Diesel, 1.77f, new List<Tank>{
                    new Tank(100, 1000),
                    new Tank(100, 500),
                })
            };

            List<GasPump> gasPumps = new List<GasPump>();
            for (int i = 0; i < Convert.ToInt32(table.Rows[1].Field<string>(1)); i++)
            {
                List<Tap> taps = new List<Tap>();
                for (int t = 0; t < 3; t++)
                {    
                        Tap tap = new Tap(gases.ElementAt(t));
                        taps.Add(tap);
                }

                gasPumps.Add(new GasPump(taps));
            }

            gasStation = new GasStation("Migrolino", gasPumps, cashRegisters);

        }
    }
}