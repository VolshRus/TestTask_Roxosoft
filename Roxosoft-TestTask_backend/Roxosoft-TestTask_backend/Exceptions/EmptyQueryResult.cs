using System;

namespace WebApp.Exceptions
{
    /// <summary>
    /// Exception that represents an unexpected empty result from db query
    /// </summary>
    public class EmptyQueryResultException:Exception
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public EmptyQueryResultException()
            : base($"There is no result in db for this request.")
        { }
    }
}
