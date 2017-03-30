using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models;

namespace Batonezas.WebApi.Infrastructure.ObjectMappings
{
    public class AutoMapperModelsProfile : Profile
    {
        public AutoMapperModelsProfile()
        {
            CreateMap<DishType, DishTypeModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<DishTypeModel, DishType>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime))
                .Ignore(d => d.Id);
        }
    }
}