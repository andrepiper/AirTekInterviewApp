using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirTek.Data.Models
{
    public class Flight
    {
        public int Day { get; set; }
        [JsonPropertyName("Flight")]
        public int Number { get; set; }
        public string Outbound { get; set; } //destination
        public string Inbound { get; set; } //arrival
    }
}
