using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp._Internal.Entities
{
    [Table("products")]
    internal class ProductEntity
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("price")]
        public double Price { get; set; }

        public IEnumerable<OrderProductEntity> OrderProducts { get; set; }
    }
}
