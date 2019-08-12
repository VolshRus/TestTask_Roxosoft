using System.ComponentModel.DataAnnotations;

namespace WebApp.Requests
{
    /// <summary>
    /// Validation model for api/orders/v1/getList request
    /// </summary>
    public class OrderDetailedRequest
    {
        /// <summary>
        /// Amount of orders in sequence
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id value does not exceed zero")]
        public int Id { get; set; }
    }
}
