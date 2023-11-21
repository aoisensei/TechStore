using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public string order_item_id { get; set; } = string.Empty;

        [Required]
        public string quantity { get; set; } = string.Empty;

        public string order_id { get; set; } = string.Empty;
        public virtual Order? order { get; set; }

        public string product_id { get; set; } = string.Empty;
        public virtual Product? product { get; set; }
    }
}
