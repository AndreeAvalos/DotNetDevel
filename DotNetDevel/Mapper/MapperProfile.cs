using AutoMapper;
using DotNetDevel.Entities;
using DotNetDevel.Models.Request;

namespace DotNetDevel.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SurveyRequest, SurveyEntity>()
                .ReverseMap();
            CreateMap<FieldSurveyRequest, FieldSurveyEntity>()
                .ReverseMap();
            CreateMap<AnswerSurveyRequest, AnswerSurveyEntity>()
                .ReverseMap();
            CreateMap<UserRequest, UserEntity>()
                .ReverseMap();
        }
    }
}
