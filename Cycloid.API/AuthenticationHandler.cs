using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Cycloid.API
{
    /// <summary>
    /// The authentication handler
    /// </summary>
    public class AuthenticationHandler : DelegatingHandler
    {
        /// <summary>
        /// The authentication handler constructor
        /// </summary>
        public AuthenticationHandler() { }

        /// <summary>
        /// Before executing action
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                return task.Result;
            }, cancellationToken);
        }
    }
}