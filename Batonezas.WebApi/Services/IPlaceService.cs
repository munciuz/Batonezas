using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.PlaceModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IPlaceService
    {
        PlaceEditModel Get(int id);
        IList<PlaceListItemModel> GetList(PlaceListFilterModel filter);
        void Create(PlaceEditModel model);
        void Edit(PlaceEditModel model);
        void Delete(int id);
    }

    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            this.placeRepository = placeRepository;
        }

        public PlaceEditModel Get(int id)
        {
            var entity = placeRepository.Get(id);

            var model = Mapper.Map<PlaceEditModel>(entity);

            return model;
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
            var entity = Mapper.Map<Place>(model);

            entity.CreatedByUserId = model.CreatedByUserId;
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
    }
}