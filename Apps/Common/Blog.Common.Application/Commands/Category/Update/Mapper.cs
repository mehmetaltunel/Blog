using AutoMapper;

namespace Blog.ProductManagement.Application.Commands.Category.Update
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Command, Blog.Common.Domain.Schames.MAIN.CategoryAggregates.Category>();
        }
    }
}