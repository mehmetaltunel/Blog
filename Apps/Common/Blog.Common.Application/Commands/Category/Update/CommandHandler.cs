using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Domain;
using MediatR;
using Blog.SharedKernel.SeedWork.Repository;

namespace Blog.ProductManagement.Application.Commands.Category.Update
{
    public class CommandHandler : IRequestHandler<Command, bool>
    {
        private IUnitOfWorkFactory<ICommonDbContext> _unitOfWork;
        public IMapper _mapper;
        public CommandHandler(IUnitOfWorkFactory<ICommonDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            using (var uow = _unitOfWork.Create(true, true))
            {
                var update = await uow.Context.MAIN.Category.UpdateAsync(new Blog.Common.Domain.Schames.MAIN.CategoryAggregates.Category
                {
                    Id = request.Id,
                    Name = request.Name,
                    ParentId = request.ParentId,
                    IsActive = request.IsActive
                });
                uow.CommitTransaction();
                return true;
            }
        }
    }
}