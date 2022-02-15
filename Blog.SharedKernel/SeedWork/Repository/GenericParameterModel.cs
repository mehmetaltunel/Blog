using Dapper;

namespace Blog.SharedKernel.SeedWork.Repository
{
    public class GenericParameterModel
    {
        public DynamicParameters Parameters { get; set; }
        public string FuncParameters { get; set; }
    }
}