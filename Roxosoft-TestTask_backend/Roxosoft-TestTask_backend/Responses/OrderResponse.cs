using System;
using System.Runtime.Serialization;

namespace WebApp.Responses
{
    /// <summary>
    /// Model that represents client's order
    /// </summary>
    [DataContract]
    public class OrderResponse
    {
        /// <summary>
        /// Identifier 
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Order creation date and time
        /// </summary>
        [DataMember(Name = "created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Status of order (in progress, active, etc.)
        /// </summary>
        [DataMember(Name = "status")]
        public int Status { get; set; }
    }
}
