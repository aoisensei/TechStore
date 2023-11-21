using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class Order
    {
        [Key]
        public string order_id { get; set; } = string.Empty;

        [Required]
        public DateTime order_date { get; set; }
        public double total_price { get; set; }

        public string user_id { get; set; } = string.Empty;
        public virtual User? user { get; set; }

        public virtual ICollection<OrderItem>? ds_orderItem { get; set; }
    }
}
