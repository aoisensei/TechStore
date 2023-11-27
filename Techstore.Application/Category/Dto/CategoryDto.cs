using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Interface;

namespace Techstore.Application.Category.Dto
{
    public class CategoryDto : IMapFrom<Domain.Entities.Category>
    {
        public string category_id { get; set; }

        public string category_name { get; set; }
    }
}
