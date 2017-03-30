using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishService
    {
        DishEditModel Get(int id);
        IList<DishListItemModel> GetList(DishListFilterModel filter);
        void Create(DishEditModel model);
        void Edit(DishEditModel model);
        void Delete(int id);
    }

    public class DishService : IDishService
    {
        private readonly IDishRepository dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public DishEditModel Get(int id)
        {
            var entity = dishRepository.Get(id);

            var model = Mapper.Map<DishEditModel>(entity);

            return model;
        }

        public IList<DishListItemModel> GetList(DishListFilterModel filter)
        {
            var query = dishRepository.CreateQuery();

            if (filter != null)
            {
                if (filter.IsValid) query = query.Where(x => x.IsValid);

                //if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => StringHelper.Contains(x.Name, filter.Name));

                if (filter.CreatedDateTime.HasValue) query = query.Where(x => x.CreatedDateTime > filter.CreatedDateTime.Value);
            }

            var list = query.AsEnumerable().Select(Mapper.Map<DishListItemModel>).ToList();

            return list;
        }

        public void Create(DishEditModel model)
        {
            var entity = Mapper.Map<Dish>(model);

            entity.CreatedByUserId = model.CreatedByUserId;
            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            dishRepository.Insert(entity);

            model.Id = entity.Id;
        }

        public void Edit(DishEditModel model)
        {
            var entity = dishRepository.Get(model.Id);

            entity.Name = model.Name;
            entity.IsValid = model.IsValid;
            entity.IsConfirmed = model.IsConfirmed;
            entity.DishTypeId = model.DishTypeId;

            dishRepository.Update(entity);
        }

        public void Delete(int id)
        {
            dishRepository.Delete(id);
        }
    }
}