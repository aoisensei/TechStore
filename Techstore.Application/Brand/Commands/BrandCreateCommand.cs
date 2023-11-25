using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Brand.Dto;
using Techstore.Application.Interface;

namespace Techstore.Application.Brand.Commands;

public record BrandCreateCommand : IRequest<BrandDto>
{
    public string brand_id { get; set; }

    public string brand_name { get; set; }
}

public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, BrandDto>
{
    private readonly IRepository<Domain.Entities.Brand> _brandRepository;
    private readonly IMapper _mapper;

    public BrandCreateCommandHandler(IRepository<Domain.Entities.Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
    {
        var brandCreate = new Domain.Entities.Brand()
        {
            brand_id = request.brand_id,
            brand_name = request.brand_name,
        };
        var result = await _brandRepository.CreateAsync(brandCreate);

        return _mapper.Map<BrandDto>(result);
    }
}
