using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FortoShipments.Shared
{
    public class Utilities
    {
        public static async Task<T> GetData<T>(string jsonFile, string folder)
        {
            var outputFolder = Path.Combine(Environment.CurrentDirectory, folder);

            var filePath = Path.Combine(outputFolder, jsonFile);

            string textContent = await File.ReadAllTextAsync(filePath);

            return JsonConvert.DeserializeObject<T>(textContent,new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

        }
    }
}
