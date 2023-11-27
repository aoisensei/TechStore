using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Category.Dto;
using Techstore.Application.Interface;

namespace Techstore.Application.Category.Commands;

public record CategoryUpdateCommand : IRequest<string>
{
    public string category_id { get; set; }

    public string category_name { get; set; }
}

public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, string>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryUpdateCommandHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var categoryUpdate = new Domain.Entities.Category()
        {
            category_id = request.category_id,
            category_name = request.category_name,
        };

        return await _categoryRepository.UpdateAsync(request.category_id, categoryUpdate);
    }
}
