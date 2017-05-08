using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models.DishModels;
using Batonezas.WebApi.Models.TagModels;
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
        void CreateDishTags(int[] tagIdList, int dishId);
    }

    public class DishService : IDishService
    {
        private readonly IDishRepository dishRepository;
        private readonly IDishTagRepository dishTagRepository;
        private readonly ITagRepository tagRepository;
        private readonly ITagService tagService;

        public DishService(IDishRepository dishRepository, 
            IDishTagRepository dishTagRepository, 
            ITagRepository tagRepository,
            ITagService tagService)
        {
            this.dishRepository = dishRepository;
            this.dishTagRepository = dishTagRepository;
            this.tagRepository = tagRepository;
            this.tagService = tagService;
        }

        public DishEditModel Get(int id)
        {
            var entity = dishRepository.Get(id);

            var model = Mapper.Map<DishEditModel>(entity);

            model.SelectedTags = entity.DishTag.Select(x => new TagListItemModel
            {
                Id = x.Tag.Id,
                Name = x.Tag.Name
            }).ToArray();

            model.AllTags = tagRepository.CreateQuery().Where(x => x.IsValid).OrderBy(x => x.Name).Select(x => new TagListItemModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToArray();

            return model;
        }

        public IList<DishListItemModel> GetList(DishListFilterModel filter)
        {
            var query = dishRepository.CreateQuery().Where(x => x.IsValid).OrderBy(x => x.Name);

            if (filter != null)
            {
                //if (filter.IsValid) query = query.Where(x => x.IsValid);

                //if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => StringHelper.Contains(x.Name, filter.Name));

                //if (filter.CreatedDateTime.HasValue) query = query.Where(x => x.CreatedDateTime > filter.CreatedDateTime.Value);
            }

            var list = query.AsEnumerable().Select(Mapper.Map<DishListItemModel>).ToList();

            return list;
        }

        public void Create(DishEditModel model)
        {
            var entity = Mapper.Map<Dish>(model);

            entity.CreatedByUserId = UserHelper.GetCurrentUserId();
            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            dishRepository.Insert(entity);

            model.Id = entity.Id;

            var dishTagIds = model.SelectedTags.Select(x => x.Id).ToArray();

            CreateDishTags(dishTagIds, entity.Id);
        }

        public void Edit(DishEditModel model)
        {
            var entity = dishRepository.Get(model.Id);

            entity.Name = model.Name;
            entity.IsValid = model.IsValid;
            entity.IsConfirmed = model.IsConfirmed;

            dishRepository.Update(entity);

            var dishTagIds = model.SelectedTags.Select(x => x.Id).ToArray();

            tagService.DeleteTagsForDish(model.Id);

            CreateDishTags(dishTagIds, model.Id);
        }

        public void Delete(int id)
        {
            dishRepository.Delete(id);
        }

        public void CreateDishTags(int[] tagIdList, int dishId)
        {
            var dish = dishRepository.Get(dishId);

            foreach (var tagId in tagIdList)
            {
                if (dish.DishTag.All(x => x.TagId != tagId))
                {
                    var dishTag = new DishTag
                    {
                        DishId = dishId,
                        TagId = tagId,
                        CreatedByUserId = 1,
                        CreatedDateTime = DateTime.Now
                    };

                    dishTagRepository.Insert(dishTag);
                }
            }
        }
    }
}