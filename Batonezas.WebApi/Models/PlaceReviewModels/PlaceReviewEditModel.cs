using Batonezas.WebApi.Models.PlaceModels;

namespace Batonezas.WebApi.Models.PlaceReviewModels
{
    public class PlaceReviewEditModel
    {
        public int Id { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }

        public string ImageUri { get; set; }

        public PlaceEditModel Place { get; set; }
    }
}