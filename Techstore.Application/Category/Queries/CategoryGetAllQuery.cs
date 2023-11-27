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

public record CategoryGetAllQuery : IRequest<List<CategoryDto>>
{

}

public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, List<CategoryDto>>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryGetAllQueryHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();

        var categoryList = _mapper.Map<List<CategoryDto>>(categories);

        return categoryList;
    }
}
