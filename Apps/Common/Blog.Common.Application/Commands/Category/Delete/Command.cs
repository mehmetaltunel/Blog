using MediatR;

namespace Common.Application.Commands.Category.Delete
{
    public class Command : IRequest<bool>
    {
        public int Id { get; set; }
    }
}