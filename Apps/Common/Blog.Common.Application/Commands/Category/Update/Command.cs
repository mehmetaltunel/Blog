using MediatR;

namespace Blog.ProductManagement.Application.Commands.Category.Update
{
    public class Command : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}