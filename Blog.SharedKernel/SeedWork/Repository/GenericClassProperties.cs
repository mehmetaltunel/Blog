using System.Data;

namespace Blog.SharedKernel.SeedWork.Repository
{
    public class GenericClassProperties
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public DbType DbType { get; set; }
    }
}

