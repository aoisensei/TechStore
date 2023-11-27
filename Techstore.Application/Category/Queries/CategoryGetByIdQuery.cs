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

namespace Techstore.Application.Category.Queries;

public record CategoryGetByIdQuery : IRequest<CategoryDto>
{
    public string category_id { get; set; }

}

public class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, CategoryDto>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryGetByIdQueryHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.category_id);

        return _mapper.Map<CategoryDto>(category);
    }
}
