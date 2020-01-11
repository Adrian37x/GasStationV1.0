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
            Tank[] allTanks = { };
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Receipts.txt";
            string[] tanks = ReadTanksFromFile(filepath);
            for (int i = 0; i < tanks.Length; i++)
            {
                Tank singleTank = JsonConvert.DeserializeObject<Tank>(tanks[i]);
                allTanks[i] = singleTank;
            }

            return allTanks;
        }

        public static Receipt[] ReadReceipts()
        {
            Receipt[] allReceipts = { };
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Receipts.txt";
            string[] receipts = ReadReceiptsFromFile(filepath);
            for (int i = 0; i < receipts.Length; i++)
            {
                Receipt singleReceipt = JsonConvert.DeserializeObject<Receipt>(receipts[i]);
                allReceipts[i] = singleReceipt;
            }

            return allReceipts;
        }

        public static void SaveTanks(Tank[] tanks)
        {
            List<TankSerialize> serializeTanks = new List<TankSerialize>();

            foreach (var tank in tanks)
            {
                TankSerialize tankSerialize = new TankSerialize();
                tankSerialize.gasType = tank.GetGasType();
                tankSerialize.literAmount = tank.GetLiterAmount();
                tankSerialize.minLiterAmount = tank.GetMinLiterAmount();
                serializeTanks.Add(tankSerialize);
            }

            string receiptJSON = JsonConvert.SerializeObject(serializeTanks);
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Receipts.txt";

            WriteTanksToFile(receiptJSON, filepath);
        }

        public static void SaveReceipt(Receipt receipt)
        {
            ReceiptSerialize receiptSerialize = new ReceiptSerialize();
            receiptSerialize.fueledLiter = receipt.GetFueledLiter();
            receiptSerialize.gasType = receipt.GetGasType();
            receiptSerialize.paymentAmount = receipt.GetPaymentAmount();
            receiptSerialize.timeStamp = receipt.GetTimeStamp();

            string receiptJSON = JsonConvert.SerializeObject(receiptSerialize);
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "SavedData\\Receipts.txt";

            AppendToFile(receiptJSON, filepath);
        }

        private static void AppendToFile(string json, string filepath)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(json);
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private static void WriteTanksToFile(string json, string filepath)
        {
            try
            {
                string[] tanks = json.Split(',');

                for (int i = 0; i < tanks.Length; i++)
                {
                    if (i == 0)
                    {
                        using (StreamWriter sw = new StreamWriter(filepath))
                        {

                            sw.WriteLine(tanks[i]);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(filepath))
                        {

                            sw.WriteLine(tanks[i]);
                        }
                    }
                } 
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        private static string[] ReadReceiptsFromFile(string filepath)
        {
            string[] textContent = { };

            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line;
                    int index = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        textContent[index] = line;
                        index++;
                    }
                }

                return textContent;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string[] ReadTanksFromFile(string filepath)
        {
            string[] textContent = { };

            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string line;
                    int index = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        textContent[index] = line;
                        index++;
                    }
                }

                return textContent;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}