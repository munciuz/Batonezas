namespace Batonezas.WebApi.Models.DishReviewModels
{
    public class GroupedPlaceReviewListItemModel
    {
        public int PlaceId { get; set; }

        public string PlaceName { get; set; }
        
        public string GId { get; set; }

        public double RatingAverage { get; set; }

        public int ReviewCount { get; set; }

        public string ImageUri { get; set; }
    }
}