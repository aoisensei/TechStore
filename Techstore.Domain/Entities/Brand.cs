using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class Brand
    {
        [Key]
        public string brand_id { get; set; } = string.Empty;

        [Required]
        public string brand_name { get; set; } = string.Empty;

        public virtual ICollection<Product>? ds_product { get; set; }
    }
}
