using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.DishTypeModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishTypeService
    {
        DishTypeModel Get(int id);
        IList<DishTypeListItemModel> GetList(DishTypeListFilterModel filter);
        void Create(DishTypeModel model);
        void Edit(DishTypeModel model);
        void Delete(int id);
    }

    public class DishTypeService : IDishTypeService
    {
        private readonly IDishTypeRepository dishTypeRepository;

        public DishTypeService(IDishTypeRepository dishTypeRepository)
        {
            this.dishTypeRepository = dishTypeRepository;
        }

        public DishTypeModel Get(int id)
        {
            var entity = dishTypeRepository.Get(id);

            var model = Mapper.Map<DishTypeModel>(entity);

            return model;
        }

        public IList<DishTypeListItemModel> GetList(DishTypeListFilterModel filter)
        {
            var query = dishTypeRepository.CreateQuery();

            if (filter != null)
            {
                if (filter.IsValid) query = query.Where(x => x.IsValid);

                //if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => StringHelper.Contains(x.Name, filter.Name));

                if (filter.CreatedDateTime.HasValue) query = query.Where(x => x.CreatedDateTime > filter.CreatedDateTime.Value);
            }

            var list = query.AsEnumerable().Select(Mapper.Map<DishTypeListItemModel>).ToList();

            return list;
        }

        public void Create(DishTypeModel model)
        {
            var entity = Mapper.Map<DishType>(model);

            entity.CreatedByUserId = model.CreatedByUserId;
            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            dishTypeRepository.Insert(entity);

            model.Id = entity.Id;
        }

        public void Edit(DishTypeModel model)
        {
            var entity = dishTypeRepository.Get(model.Id);

            entity.Name = model.Name;
            entity.IsValid = model.IsValid;

            dishTypeRepository.Update(entity);
        }

        public void Delete(int id)
        {
            dishTypeRepository.Delete(id);
        }
    }
}