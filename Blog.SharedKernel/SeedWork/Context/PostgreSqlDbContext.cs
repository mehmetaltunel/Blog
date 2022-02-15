using Npgsql;

namespace Blog.SharedKernel.SeedWork.Context
{
    public class PostgreSqlDbContext : DbContext, IPostgreSqlDbContext
    {
        public PostgreSqlDbContext(string connectionString, int commandTimeout)
        {
            Connection = new NpgsqlConnection(connectionString);
        }
    }
}