using Newtonsoft.Json;
using System;

namespace Cycloid.Models
{
    public class Event
    {
        /// <summary>
        /// The channel name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "channelName")]
        public string ChannelName { get; set; }

        /// <summary>
        /// The program title
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "programTitle")]
        public string ProgramTitle { get; set; }

        /// <summary>
        /// The program description
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "programDescription")]
        public string ProgramDescription { get; set; }

        /// <summary>
        /// The program start time
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "programStartTime")]
        public DateTime ProgramStartTime { get; set; }

        /// <summary>
        /// The program end time
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "programEndTime")]
        public DateTime ProgramEndTime { get; set; }

        /// <summary>
        /// Is subscribed or not
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isSubscribed")]
        public bool IsSubscribed { get; set; }
    }
}
