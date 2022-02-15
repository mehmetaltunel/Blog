using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Common.Domain;
using MediatR;
using Blog.SharedKernel.SeedWork.Repository;

namespace Common.Application.Commands.Category.Delete
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
                var delete = await uow.Context.MAIN.Category.DeleteAsync(request.Id);
                uow.CommitTransaction();
                return true;
            }
        }
    }
}