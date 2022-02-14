using System.Collections.Generic;
using System.Data;
using TgaCase.SharedKernel.SeedWork.Repository;

namespace TgaCase.SharedKernel.Utilities
{
    public static class GenericUtil<TEntity>
    {
        public static IList<GenericClassProperties> GetGenericProperties(TEntity T)
        {
            var entityProperties = T.GetType().GetProperties();
            List<GenericClassProperties> propertiesList = new List<GenericClassProperties>();
            foreach (var property in entityProperties)
            {
                propertiesList.Add(new GenericClassProperties
                {
                    Name = property.Name,
                    Value = property.GetValue(T),
                    DbType = GetDbType(property.PropertyType.ToString()),
                });
            }
            return propertiesList;
        }

        static DbType GetDbType(string type)
        {
            switch (type)
            {
                case "System.Int64":
                    return DbType.Int64;
                break;
                case "System.String":
                    return DbType.String;
                break;
                case "System.Int32":
                    return DbType.Int32;
                    break;
                case "System.Boolean":
                    return DbType.Boolean;
                    break;
                case "System.Nullable`1[System.Int32]":
                    return DbType.Int32;
                case "System.Decimal":
                    return DbType.Decimal;
                case "System.DateTime":
                    return DbType.Date;
                default:
                    return DbType.String;
            }
        }
    }
}
