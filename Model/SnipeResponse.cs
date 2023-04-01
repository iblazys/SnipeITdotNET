﻿using System.Text.Json.Serialization;

namespace SnipeITdotNET.Model
{
    public class SnipeResponse<T>
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("messages")]

        public string[]? Messages { get; set; }

        public T? Data { get; set; }
    }
}
