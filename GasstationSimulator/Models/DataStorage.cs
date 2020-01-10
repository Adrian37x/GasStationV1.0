using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GasstationSimulator.Models
{
    public class DataStorage
    {
        public void SaveJsonToFile()
        {
            JsonConvert.SerializeObject();
        }
    }
}