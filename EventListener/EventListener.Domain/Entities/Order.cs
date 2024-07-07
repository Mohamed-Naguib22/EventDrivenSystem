using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventListener.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTimeOffset PlacedOn { get; set; }
        public decimal Price { get; set; }
    }
}
