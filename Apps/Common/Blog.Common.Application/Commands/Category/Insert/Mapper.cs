using AutoMapper;

namespace Common.Application.Commands.Category.Insert
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Command, Blog.Common.Domain.Schames.MAIN.CategoryAggregates.Category>();
        }
    }
}