using System;
using System.Data;
using TgaCase.SharedKernel.SeedWork.Context;

namespace TgaCase.SharedKernel.SeedWork.Repository
{
    public interface IUnitOfWork<out T> : IDisposable where T : IDbContext
    {
        T Context { get; }
        void OpenConnection     ();
        void CloseConnection    ();
        void BeginTransaction   (IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CommitTransaction  ();
        void RollbackTransaction();
    }
}