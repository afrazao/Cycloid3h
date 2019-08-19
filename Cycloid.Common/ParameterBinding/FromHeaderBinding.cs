using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Cycloid.Common.ParameterBinding
{
    /// <summary>
    /// Describes how the FromHeader parameter is binded
    /// </summary>
    public class FromHeaderBinding : HttpParameterBinding
    {
        private readonly string _name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="headerName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FromHeaderBinding(HttpParameterDescriptor parameter, string headerName) : base(parameter)
        {
            if (string.IsNullOrEmpty(headerName))
            {
                throw new ArgumentNullException(nameof(headerName));
            }

            _name = headerName;
        }

        /// <summary>
        /// Fetch the header value for the parameter provided.
        /// </summary>
        /// <param name="metadataProvider"></param>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The value in the header, if no value is provided it returns empty string</returns>
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.TryGetValues(_name, out var values))
            {
                actionContext.ActionArguments[Descriptor.ParameterName] = values.FirstOrDefault();
            }
            else
            {
                actionContext.ActionArguments[Descriptor.ParameterName] = string.Empty;
            }

            var taskSource = new TaskCompletionSource<object>();
            taskSource.SetResult(null);
            return taskSource.Task;
        }
    }
}
