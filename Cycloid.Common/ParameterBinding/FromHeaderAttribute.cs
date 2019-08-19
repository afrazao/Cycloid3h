namespace Cycloid.Common.ParameterBinding
{
    /// <summary>
    /// From Header attribute
    /// </summary>
    public class FromHeaderAttribute : FromHeaderBindingAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attr"></param>
        public FromHeaderAttribute(string attr) : base(attr) { }
    }
}
