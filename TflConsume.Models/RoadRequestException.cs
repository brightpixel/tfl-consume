using System;
using Newtonsoft.Json;

namespace TflConsume.Models
{
    public partial class RoadRequestException : Exception
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("timestampUtc")]
        public DateTimeOffset TimestampUtc { get; set; }

        [JsonProperty("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonProperty("httpStatusCode")]
        public long HttpStatusCode { get; set; }

        [JsonProperty("httpStatus")]
        public string HttpStatus { get; set; }

        [JsonProperty("relativeUri")]
        public string RelativeUri { get; set; }

        [JsonProperty("message")]
        public new string Message { get; set; }
    }

    public partial class RoadRequestException
    {
        public static RoadRequestException FromJson(string json) => JsonConvert.DeserializeObject<RoadRequestException>(json, Converter.Settings);
    }
}