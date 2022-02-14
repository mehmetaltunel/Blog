using TgaCase.SharedKernel.SeedWork.Context;

namespace TgaCase.SharedKernel.SeedWork.Repository
{
    public interface IUnitOfWorkFactory<T> where T : class, IDbContext
    {
        UnitOfWork<T> Create();
        
        UnitOfWork<T> Create(bool openConnection, bool startTransaction);
    }
}