using Blog.Common.Domain.Schames.MAIN.CategoryAggregates;
using Blog.SharedKernel.SeedWork.Signatures;

namespace Blog.Common.Domain.Schames.MAIN
{
    public interface IMAINSchema : ISchema
    {
        ICategoryRepository Category { get; }
    }
}