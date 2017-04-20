namespace Batonezas.WebApi.Models.DishReviewModels
{
    public class DishReviewListItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }

        public string ImageUri { get; set; }
    }
}