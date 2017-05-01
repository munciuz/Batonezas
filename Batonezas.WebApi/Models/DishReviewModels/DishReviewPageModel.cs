using Batonezas.WebApi.Models.TagModels;

namespace Batonezas.WebApi.Models.DishReviewModels
{
    public class DishReviewPageModel
    {
        public GroupedDishReviewListItemModel[] DishReviewList { get; set; }
        
        public TagListItemModel[] TagList { get; set; }
    }
}