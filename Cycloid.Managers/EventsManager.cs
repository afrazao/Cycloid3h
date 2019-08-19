using Cycloid.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cycloid.Managers
{
    public class EventsManager : IEventsManager
    {
        public Task<List<Event>> GetEventsAsync(string deviceId, string channelId, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Event>> GetPlayingEventsAsync(string deviceId, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}
