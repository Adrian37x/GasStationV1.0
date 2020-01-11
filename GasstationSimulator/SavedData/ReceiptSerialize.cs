using GasstationSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasstationSimulator.SavedData
{
    public class ReceiptSerialize
    {
        public GasType gasType;
        public float fueledLiter;  
        public float paymentAmount;    
        public DateTime timeStamp;     
    }
}