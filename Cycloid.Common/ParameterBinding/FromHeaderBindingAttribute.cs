using System.Web.Http;
using System.Web.Http.Controllers;

namespace Cycloid.Common.ParameterBinding
{
    /// <summary>
    /// From Header abstract
    /// </summary>
    public abstract class FromHeaderBindingAttribute : ParameterBindingAttribute
    {
        private readonly string _name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerName"></param>
        protected FromHeaderBindingAttribute(string headerName)
        {
            _name = headerName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderBinding(parameter, _name);
        }
    }
}
