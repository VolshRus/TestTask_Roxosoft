using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp._Internal.Entities
{
    [Table("order_vs_product")]
    internal class OrderProductEntity
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("order")]
        public OrderEntity Order { get; set; }
        [Column("product")]
        public ProductEntity Product { get; set; }
    }
}
