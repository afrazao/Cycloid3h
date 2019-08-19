using Cycloid.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cycloid.Managers
{
    public interface IEventsManager
    {
        /// <summary>
        /// Gets the events by channel id
        /// </summary>
        /// <param name="deviceId">The device id</param>
        /// <param name="channelId">The channel id</param>
        /// <param name="ct">(optional) The cancellation token</param>
        /// <returns>The events</returns>
        Task<List<Event>> GetEventsAsync(string deviceId, string channelId, CancellationToken ct = default(CancellationToken));

        /// <summary>
        /// Gets all events playing at the moment
        /// </summary>
        /// <param name="deviceId">The device id</param>
        /// <param name="ct">(optional) The cancellation token</param>
        /// <returns></returns>
        Task<List<Event>> GetPlayingEventsAsync(string deviceId, CancellationToken ct = default(CancellationToken));
    }
}
