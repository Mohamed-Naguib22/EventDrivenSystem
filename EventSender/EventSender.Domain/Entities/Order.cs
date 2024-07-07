using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSender.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset PlacedOn { get; set; } = DateTimeOffset.Now;
        public decimal Price { get; set; }
    }
}
