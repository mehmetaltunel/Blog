using System.Collections.Generic;
using MediatR;

namespace Common.Application.Queries.Category.GetNested
{
    public class Query : IRequest<IEnumerable<CategoryGetNestedDto>>
    {
        
    }
}