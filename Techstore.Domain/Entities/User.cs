using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techstore.Domain.Entities
{
    public class User
    {
        [Key]
        public string user_id { get; set; } = string.Empty;

        [Required]
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string full_name { get; set; } = string.Empty;

        public virtual ICollection<Order> ds_order { get; set;}
    }
}
