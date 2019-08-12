namespace ClientApp.Models
{
    /// <summary>
    /// Model that represents a single product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
    }
}
