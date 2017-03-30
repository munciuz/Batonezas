using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Extensions;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Models.DishTypeModels;

namespace Batonezas.WebApi.Infrastructure.ObjectMappings
{
    public class AutoMapperModelsProfile : Profile
    {
        public AutoMapperModelsProfile()
        {
            CreateDishTypeMappings();
            CreateDishMappings();
        }

        private void CreateDishTypeMappings()
        {
            CreateMap<DishType, DishTypeModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<DishType, DishTypeListItemModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedByUser, o => o.MapFrom(s => s.User.UserName))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<DishTypeModel, DishType>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime))
                .Ignore(d => d.Id);
        }

        private void CreateDishMappings()
        {
            CreateMap<Dish, DishModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.IsConfirmed, o => o.MapFrom(s => s.IsConfirmed))
                   .ForMember(d => d.DishTypeId, o => o.MapFrom(s => s.DishTypeId))
                   .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<Dish, DishListItemModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.IsConfirmed, o => o.MapFrom(s => s.IsConfirmed))
                   .ForMember(d => d.DishTypeId, o => o.MapFrom(s => s.DishTypeId))
                   .ForMember(d => d.DishTypeName, o => o.MapFrom(s => s.DishType.Name))
                   .ForMember(d => d.CreatedByUser, o => o.MapFrom(s => s.User.UserName))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<DishModel, Dish>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.IsConfirmed, o => o.MapFrom(s => s.IsConfirmed))
                .ForMember(d => d.DishTypeId, o => o.MapFrom(s => s.DishTypeId))
                .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));
        }
    }
}