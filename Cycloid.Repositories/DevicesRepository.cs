using Cycloid.Models;

namespace Cycloid.Repositories
{
    public class DevicesRepository : IDevicesRepository
    {
        public Device GetDevice(string sessionId)
        {
            return !string.IsNullOrEmpty(sessionId)
                ? new Device { Id = sessionId.Replace("session", "device"), SessionId = sessionId, Type = "tv", UserAgent = "android" }
                : null;
        }
    }
}
