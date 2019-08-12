using System;
using System.Collections.Generic;

namespace ClientApp.Models
{
    /// <summary>
    /// Model that represents client's order
    /// </summary>
    class OrderPure: IEquatable<OrderPure>
    {
        /// <summary>
        /// Identifier 
        /// </summary>
        public int Id { get; set; }

        public string Name => $"Order # {Id}";
        /// <summary>
        /// Order creation date and time
        /// </summary>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Status of order (in progress, active, etc.)
        /// </summary>
        public OrderStatus Status { get; set; }

        public bool Equals(OrderPure other)
        {
            if (other is null)
                return false;

            return Id == other.Id && Status == other.Status;
        }
        public override bool Equals(object obj) => Equals(obj as OrderPure);
        public override int GetHashCode() => (Name, Status).GetHashCode();
    }
}
