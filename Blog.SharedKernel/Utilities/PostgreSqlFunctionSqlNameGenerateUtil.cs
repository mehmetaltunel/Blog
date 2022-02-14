using System.Collections.Generic;
using Dapper;
using TgaCase.SharedKernel.SeedWork.Repository;

namespace TgaCase.SharedKernel.Utilities
{
    public static class PostgreSqlFunctionSqlNameGenerateUtil
    {
        public static GenericParameterModel GetInsertOrUpdateFunctionParameters( IList<GenericClassProperties> properties, bool isInsert)
        {
            var param = "";
            DynamicParameters parameters = new DynamicParameters();
            int i = 0;
            foreach (var property in properties)
            {
                if (isInsert && property.Name == "Id")
                {
                    i++;
                    continue;
                }
                parameters.Add($"@{property.Name}", property.Value, property.DbType);
                param += $"@{property.Name}";
                if (i != properties.Count - (isInsert ? 2 : 1))
                    param += ",";
                i++;
            }
            return new GenericParameterModel
            {
                Parameters = parameters,
                FuncParameters = param
            };
        }
    }
}