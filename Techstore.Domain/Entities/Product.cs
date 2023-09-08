using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class Product
    {
        public string product_id { get; set; } = string.Empty;
        public string product_name { get; set;} = string.Empty;
        public double price { get; set; }
        public string description { get; set;} = string.Empty;
        public string product_img { get; set;} = string.Empty;

        public string brand_id { get; set; } = string.Empty;
        public virtual Brand? brand { get; set; }

        public string category_id { get; set; } = string.Empty;
        public virtual Category? category { get; set; }

        public virtual ICollection<OrderItem>? orderItems { get; set; }

    }
}
