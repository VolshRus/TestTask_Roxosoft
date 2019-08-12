using System.Threading.Tasks;

namespace ClientApp.Utils
{
    /// <summary>
    /// Builder for creating and executing Http requests
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Set external url
        /// </summary>
        /// <param name="url">Absolute path</param>
        IRequestServiceQuery FromUrl(string url);
    }

    /// <summary>
    /// Special interface to add params
    /// </summary>
    public interface IRequestServiceQuery
    {
        /// <summary>
        /// Add query params
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="value">Param value</param>
        IRequestServiceQuery With(object key, object value);

        /// <summary>
        /// Execure http request
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        Task<T> GetAsync<T>();
    }
}
