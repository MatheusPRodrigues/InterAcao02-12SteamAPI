using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Steam.Models.ResponseAPI
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public Price Price { get; set; }

        [JsonPropertyName("tiny_image")]
        public string TinyImage { get; set; }

        [JsonPropertyName("platforms")]
        public Platforms Platforms { get; set; }
    }
}
