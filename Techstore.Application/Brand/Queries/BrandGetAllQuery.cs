using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Techstore.Application.Brand.Dto;
using Techstore.Application.Interface;

namespace Techstore.Application.Brand.Queries;

public record BrandGetAllQuery : IRequest<List<BrandDto>>
{

}

public class BrandGetAllQueryHandler : IRequestHandler<BrandGetAllQuery, List<BrandDto>>
{
    private readonly IRepository<Domain.Entities.Brand> _brandRepository;
    private readonly IMapper _mapper;

    public BrandGetAllQueryHandler(IRepository<Domain.Entities.Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<List<BrandDto>> Handle(BrandGetAllQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllAsync();
        //var brandList = brands.Select(x => new BrandDto 
        //{
        //    brand_id = x.brand_id, 
        //    brand_name = x.brand_name 
        //}).ToList();

        var brandList = _mapper.Map<List<BrandDto>>(brands);

        return brandList;
    }
}
