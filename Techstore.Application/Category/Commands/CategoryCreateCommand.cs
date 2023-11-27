using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Brand.Dto;
using Techstore.Application.Category.Dto;
using Techstore.Application.Interface;

namespace Techstore.Application.Category.Commands;

public record CategoryCreateCommand : IRequest<CategoryDto>
{
    public string category_id { get; set; }

    public string category_name { get; set; }
}

public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, CategoryDto>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryCreateCommandHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var categoryCreate = new Domain.Entities.Category()
        {
            category_id = request.category_id,
            category_name = request.category_name,
        };
        var result = await _categoryRepository.CreateAsync(categoryCreate);

        return _mapper.Map<CategoryDto>(result);
    }
}
