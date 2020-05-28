using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using LoopUp.Model;

namespace LoopUp.Data
{
    public class Repository : IRepository
    {
        private string _datafilePath = @"E:\IT\Tests\LoopUp\LoopUp\Data\formatting.json";

        public List<UKFormatter> GetUKFormats()
        {
            return ReadJsonDataFile();
        }


        private List<UKFormatter> ReadJsonDataFile()
        {
            var ukFormatter = new List<UKFormatter>();
            var serializer = new JsonSerializer();
            using (StreamReader file = File.OpenText(_datafilePath))
            {
                using (JsonReader reader = new JsonTextReader(file))
                {
                    ukFormatter = serializer.Deserialize<List<UKFormatter>>(reader);
                }
            }

            return ukFormatter;
        }
    }
}
