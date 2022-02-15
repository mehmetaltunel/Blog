using System.Data;

namespace Blog.SharedKernel.SeedWork.Context
{
    public abstract class DbContext : IDbContext
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public int CommandTimeout { get; set; }
    }
}