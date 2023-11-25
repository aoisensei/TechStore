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

public record BrandUpdateCommand : IRequest<string>
{
    public string brand_id { get; set; }

    public string brand_name { get; set; }
}

public class BrandUpdateCommandHandler : IRequestHandler<BrandUpdateCommand, string>
{
    private readonly IRepository<Domain.Entities.Brand> _brandRepository;
    private readonly IMapper _mapper;

    public BrandUpdateCommandHandler(IRepository<Domain.Entities.Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(BrandUpdateCommand request, CancellationToken cancellationToken)
    {
        var brandUpdate = new Domain.Entities.Brand()
        {
            brand_id = request.brand_id,
            brand_name = request.brand_name,
        };

        return await _brandRepository.UpdateAsync(request.brand_id, brandUpdate);

    }
}
