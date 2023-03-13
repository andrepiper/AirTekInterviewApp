using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirTek.Data.Models
{
    public class Order
    {
        public string OrderNo { get; set; }
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
    }
}
