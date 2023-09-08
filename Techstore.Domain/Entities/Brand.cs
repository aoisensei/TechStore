using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class Brand
    {
        public string brand_id { get; set; } = string.Empty;
        public string brand_name { get; set; } = string.Empty;

        public virtual ICollection<Product>? products { get; set; }
    }
}
