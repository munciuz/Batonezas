using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Models.PlaceTypeModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IPlaceService
    {
        PlaceEditModel Get(int id);
        int GetPlaceId(PlaceEditModel model);
        IList<PlaceListItemModel> GetList(PlaceListFilterModel filter);
        void Create(PlaceEditModel model);
        void Edit(PlaceEditModel model);
        void Delete(int id);
        IList<PlaceTypeListItemModel> GetPlaceTypes();
    }

    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository placeRepository;
        private readonly IPlaceTypeRepository placeTypeRepository;

        public PlaceService(IPlaceRepository placeRepository, 
            IPlaceTypeRepository placeTypeRepository)
        {
            this.placeRepository = placeRepository;
            this.placeTypeRepository = placeTypeRepository;
        }

        public PlaceEditModel Get(int id)
        {
            var entity = placeRepository.Get(id);

            //var model = Mapper.Map<PlaceEditModel>(entity);

            var model = new PlaceEditModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                GId = entity.GId,
                Lat = entity.Lat,
                Lng = entity.Lng,
                IsValid = entity.IsValid
            };

            return model;
        }

        public IList<PlaceTypeListItemModel> GetPlaceTypes()
        {
            var result = placeTypeRepository.CreateQuery().Select(x => new PlaceTypeListItemModel
            {
                Id = x.Id,
                Name = x.Name
            });

            return result.ToList();
        }

        public IList<PlaceListItemModel> GetList(PlaceListFilterModel filter)
        {
            var query = placeRepository.CreateQuery();

            if (filter != null)
            {
                if (filter.IsValid) query = query.Where(x => x.IsValid);
            }

            var list = query.AsEnumerable().Select(Mapper.Map<PlaceListItemModel>).ToList();

            return list;
        }

        public void Create(PlaceEditModel model)
        {
            if (model.Lat.Length >= 16)
            {
                model.Lat = model.Lat.Substring(0, 16);
            }

            if (model.Lng.Length >= 16)
            {
                model.Lng = model.Lng.Substring(0, 16);
            }

            var entity = Mapper.Map<Place>(model);

            entity.CreatedByUserId = UserHelper.GetCurrentUserId();
            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            placeRepository.Insert(entity);

            model.Id = entity.Id;
        }

        public void Edit(PlaceEditModel model)
        {
            var entity = placeRepository.Get(model.Id);

            entity.Name = model.Name;
            entity.IsValid = model.IsValid;

            placeRepository.Update(entity);
        }

        public void Delete(int id)
        {
            placeRepository.Delete(id);
        }

        public int GetPlaceId(PlaceEditModel model)
        {
            int id;
            var place = placeRepository.CreateQuery().SingleOrDefault(x => x.GId == model.GId);

            if (place == null)
            {
                Create(model);

                id = model.Id;
            }
            else
            {
                id = place.Id;
            }

            return id;
        }
    }
}