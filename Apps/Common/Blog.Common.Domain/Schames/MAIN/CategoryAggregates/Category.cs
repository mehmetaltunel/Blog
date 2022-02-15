using Blog.SharedKernel.SeedWork.Entity;
using Blog.SharedKernel.SeedWork.Signatures;

namespace Blog.Common.Domain.Schames.MAIN.CategoryAggregates
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}