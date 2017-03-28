using System;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IDishTypeService
    {
        int Edit(DishTypeModel model);
    }

    public class DishTypeService : IDishTypeService
    {
        private readonly IDishTypeRepository dishTypeRepository;

        public DishTypeService(IDishTypeRepository dishTypeRepository)
        {
            this.dishTypeRepository = dishTypeRepository;
        }

        public int Edit(DishTypeModel model)
        {
            var entity = Mapper.Map<DishType>(model);

            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            dishTypeRepository.Insert(entity);
            dishTypeRepository.Save();

            return entity.Id;
        }
    }
}