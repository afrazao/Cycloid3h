using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace Cycloid.API
{
    public sealed class UnityResolver : IDependencyResolver
    {
        /// <summary>
        /// Container
        /// </summary>
        private readonly IUnityContainer _container;

        /// <inheritdoc />
        public UnityResolver(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <inheritdoc />
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        /// <inheritdoc />
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        /// <inheritdoc />
        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (disposing)
                _container.Dispose();
        }
    }
}