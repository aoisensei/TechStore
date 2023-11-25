using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Interface;
using Techstore.Domain.Entities;

namespace Techstore.Application.Brand.Dto;

public class BrandDto : IMapFrom<Domain.Entities.Brand>
{
    public string brand_id { get; set; }

    public string brand_name { get; set; }
}

