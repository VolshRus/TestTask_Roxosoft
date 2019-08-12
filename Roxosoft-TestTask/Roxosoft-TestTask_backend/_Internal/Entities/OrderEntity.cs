using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp._Internal.Entities
{
    [Table("orders")]
    internal class OrderEntity
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("created")]
        public DateTimeOffset Created { get; set; }
        [Column("status")]
        public OrderStatusEntity Status { get; set; }

        public IEnumerable<OrderProductEntity> OrderProducts { get; set; }
    }
}
