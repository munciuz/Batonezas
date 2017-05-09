using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface ITagService
    {
        TagEditModel Get(int id);
        IList<TagListItemModel> GetList(TagListFilterModel filter);
        void Create(TagEditModel model);
        void Edit(TagEditModel model);
        void Delete(int id);
        void DeleteTagsForDish(int dishId);
    }

    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        private readonly IDishTagRepository dishTagRepository;

        public TagService(ITagRepository tagRepository,
            IDishTagRepository dishTagRepository)
        {
            this.tagRepository = tagRepository;
            this.dishTagRepository = dishTagRepository;
        }

        public TagEditModel Get(int id)
        {
            var entity = tagRepository.Get(id);

            var model = Mapper.Map<TagEditModel>(entity);

            return model;
        }

        public IList<TagListItemModel> GetList(TagListFilterModel filter)
        {
            var query = tagRepository.CreateQuery().OrderBy(x => x.Name);

            if (filter != null)
            {
                //if (filter.IsValid) query = query.Where(x => x.IsValid);

                //if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => StringHelper.Contains(x.Name, filter.Name));

                //if (filter.CreatedDateTime.HasValue) query = query.Where(x => x.CreatedDateTime > filter.CreatedDateTime.Value);
            }

            var list = query.AsEnumerable().Select(Mapper.Map<TagListItemModel>).ToList();

            return list;
        }

        public void Create(TagEditModel model)
        {
            var entity = Mapper.Map<Tag>(model);

            entity.CreatedByUserId = model.CreatedByUserId;
            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            tagRepository.Insert(entity);

            model.Id = entity.Id;
        }

        public void Edit(TagEditModel model)
        {
            var entity = tagRepository.Get(model.Id);

            entity.Name = model.Name;
            entity.IsValid = model.IsValid;

            tagRepository.Update(entity);
        }

        public void Delete(int id)
        {
            tagRepository.Delete(id);
        }

        public void DeleteTagsForDish(int dishId)
        {
            var dishTags = dishTagRepository.CreateQuery().Where(x => x.DishId == dishId);

            foreach (var dishTag in dishTags)
            {
                dishTagRepository.Delete(dishTag);
            }
        }
    }
}