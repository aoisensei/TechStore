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

public record CategoryDeleteCommand : IRequest<string>
{
    public string category_id { get; set; }

}

public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, string>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryDeleteCommandHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.DeleteAsync(request.category_id);
    }
}
