using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirTek.Utils
{
    public class JsonFileReader<T>: IJsonFileReader<T> where T: class
    {
        public async Task<T> Read(string filePath)
        {
            using FileStream stream = File.OpenRead(filePath);
            if (stream == null)
                throw new Exception($"Json file not found: {filePath}");
            else
                return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
