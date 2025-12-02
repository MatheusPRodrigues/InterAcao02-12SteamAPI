using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Steam.Models.ResponseAPI
{
    public class Price
    {
        [JsonPropertyName("initial")]
        public decimal Initial { get; set; }

        [JsonPropertyName("final")]
        public decimal Final { get; set; }
    }
}
