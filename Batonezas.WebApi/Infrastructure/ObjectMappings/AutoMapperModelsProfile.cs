﻿using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Extensions;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Models.TagModels;

namespace Batonezas.WebApi.Infrastructure.ObjectMappings
{
    public class AutoMapperModelsProfile : Profile
    {
        public AutoMapperModelsProfile()
        {
            CreateDishMappings();
            CreateTagMappings();
            CreatePlaceMappings();
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

        public void CreatePlaceMappings()
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
    }
}