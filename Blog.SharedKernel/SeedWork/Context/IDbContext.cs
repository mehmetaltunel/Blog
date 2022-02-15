using System.Data;

namespace Blog.SharedKernel.SeedWork.Context
{
    public interface IDbContext
    {
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }
    }
}