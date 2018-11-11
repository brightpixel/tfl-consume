using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TflConsume.Models
{
    public partial class RoadRequestResponse
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("statusSeverity")]
        public string StatusSeverity { get; set; }

        [JsonProperty("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }

        [JsonProperty("bounds")]
        public string Bounds { get; set; }

        [JsonProperty("envelope")]
        public string Envelope { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class RoadRequestResponse
    {
        public static RoadRequestResponse[] FromJson(string json) => JsonConvert.DeserializeObject<RoadRequestResponse[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RoadRequestResponse[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
