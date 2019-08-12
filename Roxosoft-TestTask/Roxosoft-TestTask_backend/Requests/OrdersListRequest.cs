using System.ComponentModel.DataAnnotations;

namespace WebApp.Requests
{
    /// <summary>
    /// Validation model for api/orders/v1/getList request
    /// </summary>
    public class OrdersListRequest
    {
        /// <summary>
        /// Ordinal number (from zero) of first order in sequence
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Start value is below zero")]
        public int Start { get; set; }

        /// <summary>
        /// Amount of orders in sequence. Set <see langword="null"/> for all available items
        /// </summary>
        [Range(1,int.MaxValue, ErrorMessage = "Amount value does not exceed zero")]
        public int? Amount { get; set; }
    }
}
