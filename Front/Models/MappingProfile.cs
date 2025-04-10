using AutoMapper;

namespace Front.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Comment, CreateComment>().ReverseMap();
        }
    }
}
