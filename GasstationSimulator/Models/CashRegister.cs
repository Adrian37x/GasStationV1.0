using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class CashRegister
    {
        private float[] coinTypes;              // every existing coin value of that register
        private List<float> input;              // every inserted coin by user
        private float[] change;                 // change when user pays too much
        private Receipt receiptOfPayment;       // createt receipt when user pays
        private int? gasPumpIndexOfPayment;     // gas pump index of current payment (null if not occupied)

        #region get set methods
        public float[] GetCoinTypes()
        {
            return coinTypes;
        }

        public float[] GetChange()
        {
            return change;
        }

        public Receipt GetReceiptOfPayment()
        {
            return receiptOfPayment;
        }

        public int? GetGasPumpIndexOfPayment()
        {
            return gasPumpIndexOfPayment;
        }

        public void SetGasPumpIndexOfPayment(int? gasPumpIndexOfPayment)
        {
            this.gasPumpIndexOfPayment = gasPumpIndexOfPayment;
        }
        #endregion

        public CashRegister(float[] coinTypes)
        {
            this.coinTypes = coinTypes;
            this.input = new List<float>();
            this.change = new float[0];
            this.gasPumpIndexOfPayment = null;
        }

        public float GetTotalInput()
        {
            float totalInput = 0;

            // iterates through every coin insert of user
            for (int i = 0; i < input.Count; i++)
            {
                // summes up total by input in array
                totalInput += input[i];
            }

            return totalInput;
        }

        public float GetTotalChange()
        {
            float totalChange = 0;

            // iterates through every change value of the total change amount
            for (int i = 0; i < change.Length; i++)
            {
                // summes up total by change in array
                totalChange += change[i];
            }

            return totalChange;
        }

        public void InsertMoney(float value)
        {
            // adds coin in the input list of user
            input.Add(value);
        }

        public void AcceptInput(float paymentAmount)
        {
            // calc change amount
            float changeAmount = (float)Math.Round((GetTotalInput() - paymentAmount) * 20) / 20;
            GetChange(changeAmount);

            // creates the receipt of the current payment
            CreateReceipt();
        }

        private void GetChange(float changeAmount)
        {
            List<float> changeCoins = new List<float>();

            // iterates through every coin type (sortet: highest first)
            for (int i = 0; i < coinTypes.Length; i++)
            {
                // checks if the coin value isn't higher than the change amount
                while (changeAmount >= coinTypes[i])
                {
                    // add change coin to the total change list
                    changeCoins.Add(coinTypes[i]);

                    // decreases change amount by the coin value
                    changeAmount -= coinTypes[i];
                    changeAmount = (float)(Math.Round(changeAmount * 20) / 20);
                }
            }

            this.change = changeCoins.ToArray();
        }

        private void CreateReceipt()
        {
            // get gas pump index of current payment (if null then -1)
            int gasPumpIndex = gasPumpIndexOfPayment ?? -1;

            // if gas pump index exists (not if -1)
            if (gasPumpIndex >= 0)
            {
                // get selected gas pump
                GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];

                // creates receipt with gas pump data
                receiptOfPayment = new Receipt(gasPump.GetSelectedGasType() ?? GasType.Empty, gasPump.GetFueledLiter(), gasPump.GetPaymentAmount(), DateTime.Now);

                // %TODO%
                // Serialize.SaveReceipt(receiptOfPayment);
            }
        }

        public void Clear()
        {
            // clears attributes for next payment
            input = new List<float>();
            change = new float[0];
            receiptOfPayment = null;
            gasPumpIndexOfPayment = null;
        }
    }
}