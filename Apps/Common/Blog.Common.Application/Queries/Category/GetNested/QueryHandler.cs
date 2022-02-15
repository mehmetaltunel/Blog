using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Domain;
using MediatR;
using Blog.SharedKernel.SeedWork.Repository;

namespace Common.Application.Queries.Category.GetNested
{
    public class QueryHandler : IRequestHandler<Query, IEnumerable<CategoryGetNestedDto>>
    {
        private IUnitOfWorkFactory<ICommonDbContext> _unitOfWork;
        private IMapper _mapper;
        public QueryHandler(IUnitOfWorkFactory<ICommonDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryGetNestedDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            using (var uow = _unitOfWork.Create(true, false))
            {
                var categories = await uow.Context.MAIN.Category.GetAllAsync();
                var nested = CreateNestedCategories(categories);
                return nested;
            }
        }

        //kategorileri nested şekilde alıyoruz, (id parentid ilişkisi)
        private IEnumerable<CategoryGetNestedDto> CreateNestedCategories(IEnumerable<Blog.Common.Domain.Schames.MAIN.CategoryAggregates.Category> items, long? id = null)
        {
            foreach (var item in id.HasValue ? items.Where(x => x.ParentId == id) : items.Where(x => !x.ParentId.HasValue))
            {
                yield return new CategoryGetNestedDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsActive = item.IsActive,
                    Children = CreateNestedCategories(items, item.Id)
                };
            }
        }
    }

}