using AutoMapper;
using Blazor.Data.Entities.NewsEntities;
using Blazor.Model.NewsDtos;

namespace Blazor.Business.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<News, NewsDTO>().ReverseMap();
        }
    }
}
