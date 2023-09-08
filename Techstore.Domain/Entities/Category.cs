using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class Category
    {
        public string category_id { get; set; } = string.Empty;
        public string category_name { get; set; } = string.Empty;

        public virtual ICollection<Product>? products { get; set; }
    }
}
