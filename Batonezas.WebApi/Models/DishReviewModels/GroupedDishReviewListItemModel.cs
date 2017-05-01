namespace Batonezas.WebApi.Models.DishReviewModels
{
    public class GroupedDishReviewListItemModel
    {
        public int DishId { get; set; }

        public string DishName { get; set; }

        public int PlaceId { get; set; }

        public string PlaceName { get; set; }
        
        public string GId { get; set; }

        public double RatingAverage { get; set; }

        public int ReviewCount { get; set; }

        public string ImageUri { get; set; }
    }
}