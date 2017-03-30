using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.ReviewModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IReviewService
    {
        ReviewEditModel Get(int id);
        IList<ReviewListItemModel> GetList(ReviewListFilterModel filter);
        void Create(ReviewEditModel model);
        void Edit(ReviewEditModel model);
        void Delete(int id);
    }

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public ReviewEditModel Get(int id)
        {
            var entity = reviewRepository.Get(id);

            var model = Mapper.Map<ReviewEditModel>(entity);

            return model;
        }

        public IList<ReviewListItemModel> GetList(ReviewListFilterModel filter)
        {
            var query = reviewRepository.CreateQuery();

            if (filter != null)
            {
                if (filter.IsValid) query = query.Where(x => x.IsValid);

                if (filter.CreatedDateTime.HasValue) query = query.Where(x => x.CreatedDateTime > filter.CreatedDateTime.Value);
            }

            var list = query.AsEnumerable().Select(Mapper.Map<ReviewListItemModel>).ToList();

            return list;
        }

        public void Create(ReviewEditModel model)
        {
            var entity = Mapper.Map<Review>(model);

            entity.CreatedByUserId = model.CreatedByUserId;
            entity.CreatedDateTime = DateTime.Now;
            entity.IsValid = true;

            reviewRepository.Insert(entity);

            model.Id = entity.Id;
        }

        public void Edit(ReviewEditModel model)
        {
            var entity = reviewRepository.Get(model.Id);
            
            entity.IsValid = model.IsValid;

            reviewRepository.Update(entity);
        }

        public void Delete(int id)
        {
            reviewRepository.Delete(id);
        }
    }
}