using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class OrderItem
    {
        public string order_item_id { get; set; } = string.Empty;
        public string quantity { get; set; } = string.Empty;

        public string order_id { get; set; } = string.Empty;
        public virtual Order? order { get; set; }

        public string product_id { get; set; } = string.Empty;
        public virtual Product? product { get; set; }
    }
}
