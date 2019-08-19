using Newtonsoft.Json;

namespace Cycloid.Models
{
    /// <summary>
    /// The channel class
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// The channel identifier
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The display name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The position
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "position")]
        public int Position { get; set; }
    }
}
