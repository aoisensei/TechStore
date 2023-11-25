using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Interface;

namespace Techstore.Application.Brand.Commands;

public record BrandDeleteCommand : IRequest<string>
{
    public string brand_id { get; set; }

}

public class BrandDeleteCommandHandler : IRequestHandler<BrandDeleteCommand, string>
{
    private readonly IRepository<Domain.Entities.Brand> _brandRepository;
    private readonly IMapper _mapper;

    public BrandDeleteCommandHandler(IRepository<Domain.Entities.Brand> brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(BrandDeleteCommand request, CancellationToken cancellationToken)
    {
        return await _brandRepository.DeleteAsync(request.brand_id);
    }
}
