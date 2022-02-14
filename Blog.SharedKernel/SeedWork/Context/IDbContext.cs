using System.Data;

namespace TgaCase.SharedKernel.SeedWork.Context
{
    public interface IDbContext
    {
        IDbConnection  Connection  { get; set; }
        IDbTransaction Transaction { get; set; } 
    }
}