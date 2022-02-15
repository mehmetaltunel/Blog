using Blog.Common.Domain.Schames.MAIN;
using Blog.SharedKernel.SeedWork.Context;

namespace Blog.Common.Domain
{
    public interface ICommonDbContext : IDbContext
    {
        IMAINSchema MAIN { get; }
    }
}