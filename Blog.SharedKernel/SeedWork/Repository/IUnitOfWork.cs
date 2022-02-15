using System;
using System.Data;
using Blog.SharedKernel.SeedWork.Context;

namespace Blog.SharedKernel.SeedWork.Repository
{
    public interface IUnitOfWork<out T> : IDisposable where T : IDbContext
    {
        T Context { get; }
        void OpenConnection();
        void CloseConnection();
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CommitTransaction();
        void RollbackTransaction();
    }
}