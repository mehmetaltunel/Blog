using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TgaCase.SharedKernel.Utilities;

namespace TgaCase.SharedKernel.SeedWork.Repository
{
    public abstract class RepositoryBase
    {
        protected readonly IDbConnection  DbConnection;

        protected readonly IDbTransaction DbTransaction;
        
        protected readonly int            CommandTimeout;
        protected readonly string         SchemaName;
        
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction,string schemaName, int commandTimeout = 30)
        {
            DbConnection   = dbConnection;
            DbTransaction  = dbTransaction;
            CommandTimeout = commandTimeout;
            SchemaName     = schemaName;
        }
        
    }

    public abstract class RepositoryBase<TEntity, TId> : RepositoryBase, IRepository<TEntity, TId>
        where TEntity : class where TId : struct
    {
        protected RepositoryBase(IDbConnection dbConnection, IDbTransaction dbTransaction, string schemaName, int commandTimeout = 30) : base(dbConnection, dbTransaction, schemaName, commandTimeout)
        {
        }

      public async virtual Task<TId> InsertAsync(TEntity input)
        {
            var properties = GenericUtil<TEntity>.GetGenericProperties(input);
            var prm = PostgreSqlFunctionSqlNameGenerateUtil.GetInsertOrUpdateFunctionParameters(properties, true);
            var prmName = prm.FuncParameters.Replace("@",@"""").Replace(",", @""",") + @""""; // Postgre büyük harfle olduğu için propertylerin başına  ve sonun " eklenmeli
            var sql = $@"insert into ""{SchemaName}"".""{typeof(TEntity).Name}"" ({prmName}) values({prm.FuncParameters}) RETURNING ""Id""";
            var res = await DbConnection.ExecuteScalarAsync<TId>(sql, prm.Parameters,commandType: CommandType.Text, transaction: DbTransaction, commandTimeout: CommandTimeout);
            return res;
        }
        
        public async virtual Task<bool> UpdateAsync(TEntity input)
        {
            var properties = GenericUtil<TEntity>.GetGenericProperties(input);
            var prm = PostgreSqlFunctionSqlNameGenerateUtil.GetInsertOrUpdateFunctionParameters(properties, false);
            var prmNames = (prm.FuncParameters.Replace("@", @"""").Replace(",", @""",") + @"""").Replace(")",String.Empty).Replace("(",String.Empty);
            var paramSplit = prmNames.Split(',');
            string updParams = @"";
            int i = 0;
            foreach (var prmm in paramSplit)
            {
                if (prmm != @"""Id""")
                {
                    updParams += $@"{prmm}= @{prmm.Replace(@"""",String.Empty)}";
                    updParams += ",";
                }
            }

            if (updParams[updParams.Length - 1] == ',')
                updParams = updParams.Substring(0, updParams.Length - 1);
            var sql = $@"update ""{SchemaName}"".""{typeof(TEntity).Name}"" set {updParams} where ""Id"" = @Id ";
            return await DbConnection.ExecuteScalarAsync<bool>(sql, prm.Parameters,commandType: CommandType.Text, transaction: DbTransaction,
                commandTimeout: CommandTimeout);
        }
        
        public async virtual Task<bool> DeleteAsync(long id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id",id);
            var sql = $@"delete from ""{SchemaName}"".""{typeof(TEntity).Name}""where ""Id"" = @id ";
            var response = await DbConnection.ExecuteScalarAsync<bool>(sql, parameters,
                commandType: CommandType.Text,transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response;        
        }
        
        public async virtual Task<IList<TEntity>> GetAllAsync()
        {
            var sql = $@"select * from ""{SchemaName}"".""{typeof(TEntity).Name}""";
            var response = await DbConnection.QueryAsync<TEntity>(sql,
                transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response.ToList();
        }

        public async virtual Task<TEntity> GetByIdAsync(TId id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32);
            var sql = $@"select * from ""{SchemaName}"".""{typeof(TEntity).Name}"" where ""Id""=@id";
            var response = await DbConnection.QueryFirstOrDefaultAsync<TEntity>(sql, parameters,
                transaction: DbTransaction, commandTimeout: CommandTimeout);
            return  response;
        }
    }
}