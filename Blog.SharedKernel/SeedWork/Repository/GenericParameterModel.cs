using Dapper;

namespace TgaCase.SharedKernel.SeedWork.Repository
{
    public class GenericParameterModel
    {
        public DynamicParameters Parameters { get; set; }
        public string FuncParameters { get; set; }
    }
}