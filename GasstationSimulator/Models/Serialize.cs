using GasstationSimulator.SavedData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace GasstationSimulator.Models
{
    public static class Serialize
    {
        public static Tank[] ReadTanks()
        {
            try
            {
                List<Tank> tanks = new List<Tank>();

                string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Tanks.txt";

                using (StreamReader sr = new StreamReader(filepath))
                {
                    tanks = JsonConvert.DeserializeObject<List<Tank>>(sr.ReadToEnd());
                }

                if (tanks == null)
                    return new Tank[0];

                return tanks.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Receipt[] ReadReceipts()
        {
            try
            {
                List<Receipt> receipts = new List<Receipt>();

                string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Receipts.txt";

                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (sr.Peek() >= 0)
                    {
                        Receipt receipt = JsonConvert.DeserializeObject<Receipt>(sr.ReadLine());
                        receipts.Add(receipt);
                    }
                }

                return receipts.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void SaveTanks(Tank[] tanks)
        {
            // create list of serializable tanks
            List<TankSerialize> serializeTanks = new List<TankSerialize>();

            foreach (Tank tank in tanks)
            {
                serializeTanks.Add(new TankSerialize(tank));
            }

            string tanksJSON = JsonConvert.SerializeObject(serializeTanks);
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Tanks.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    sw.Write(tanksJSON);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void SaveReceipt(Receipt receipt)
        {
            // create serializable receipt 
            ReceiptSerialize serializeReceipt = new ReceiptSerialize(receipt);

            string receiptJSON = JsonConvert.SerializeObject(serializeReceipt);
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Receipts.txt";

            try
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(receiptJSON);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}