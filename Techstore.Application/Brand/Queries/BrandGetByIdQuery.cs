using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Brand.Dto;
using Techstore.Application.Interface;

namespace Techstore.Application.Brand.Queries;

public record BrandGetByIdQuery : IRequest<BrandDto>
{
    public string brand_id { get; set; }
}

public class BrandGetByIdQueryHandler : IRequestHandler<BrandGetByIdQuery, BrandDto>
{
    private readonly IRepository<Domain.Entities.Brand> _brandRepository;
    private readonly IMapper _mapper;

    public BrandGetByIdQueryHandler(IRepository<Domain.Entities.Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(BrandGetByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetByIdAsync(request.brand_id);

        return _mapper.Map<BrandDto>(brand);
    }
}
