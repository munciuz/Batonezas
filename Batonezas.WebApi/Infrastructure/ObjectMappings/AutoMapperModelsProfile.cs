using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Extensions;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Models.PlaceReviewModels;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Models.UserModels;

namespace Batonezas.WebApi.Infrastructure.ObjectMappings
{
    public class AutoMapperModelsProfile : Profile
    {
        public AutoMapperModelsProfile()
        {
            CreateUserMappings();
            CreateDishMappings();
            CreateTagMappings();
            CreatePlaceMappings();
            CreatePlaceReviewMappings();
        }

        private void CreateUserMappings()
        {
            CreateMap<User, UserEditModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Username, o => o.MapFrom(s => s.UserName))
                   .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));

            CreateMap<User, UserListItemModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Username, o => o.MapFrom(s => s.UserName))
                   .ForMember(d => d.Email, o => o.MapFrom(s => s.Email));
        }

        private void CreateDishMappings()
        {
            CreateMap<Dish, DishEditModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.IsConfirmed, o => o.MapFrom(s => s.IsConfirmed))
                   .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<Dish, DishListItemModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.IsConfirmed, o => o.MapFrom(s => s.IsConfirmed))
                   .ForMember(d => d.CreatedByUser, o => o.MapFrom(s => s.User.UserName))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<DishEditModel, Dish>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.IsConfirmed, o => o.MapFrom(s => s.IsConfirmed))
                .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));
        }

        private void CreateTagMappings()
        {
            CreateMap<Tag, TagEditModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<TagEditModel, Tag>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.CreatedByUserId, o => o.MapFrom(s => s.CreatedByUserId))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<Tag, TagListItemModel>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                   .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                   .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));

            CreateMap<TagListItemModel, Tag>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));
        }

        private void CreatePlaceMappings()
        {
            CreateMap<PlaceEditModel, Place>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.GId, o => o.MapFrom(s => s.GId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.Lat, o => o.MapFrom(s => s.Lat))
                .ForMember(d => d.Lng, o => o.MapFrom(s => s.Lng))
                .ForMember(d => d.IsValid, o => o.MapFrom(s => s.IsValid))
                .ForMember(d => d.CreatedDateTime, o => o.MapFrom(s => s.CreatedDateTime));
        }

        private void CreatePlaceReviewMappings()
        {
            CreateMap<PlaceReviewEditModel, Review>()
                .Ignore(d => d.Id)
                .ForMember(d => d.Rating, o => o.MapFrom(s => s.Rating))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Review));
        }
    }
}