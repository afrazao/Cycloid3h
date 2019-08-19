using Newtonsoft.Json;
using System;

namespace Cycloid.Models
{
    /// <summary>
    /// The program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The program identifier
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The channel identifier
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// The image url
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The start time
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "endTime")]
        public DateTime EndTime { get; set; }
    }
}
