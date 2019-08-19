using Cycloid.Models;

namespace Cycloid.Repositories
{
    public interface IDevicesRepository
    {
        /// <summary>
        /// Gets the device for a given session id
        /// </summary>
        /// <param name="sessionId">The session id</param>
        /// <returns>The device</returns>
        Device GetDevice(string sessionId);
    }
}
