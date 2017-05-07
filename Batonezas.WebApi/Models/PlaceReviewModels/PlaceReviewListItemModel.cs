namespace Batonezas.WebApi.Models.PlaceReviewModels
{
    public class PlaceReviewListItemModel
    {
        public int Id { get; set; }

        public string PlaceName { get; set; }

        public string GId { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }

        public string ImageUri { get; set; }

        public string ReviewedBy { get; set; }
    }
}