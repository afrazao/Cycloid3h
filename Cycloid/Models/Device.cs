using Newtonsoft.Json;

namespace Cycloid.Models
{
    public class Device
    {
        /// <summary>
        /// The identifier
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The session identifier
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// The type
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The user agent
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "userAgent")]
        public string UserAgent { get; set; }
    }
}
