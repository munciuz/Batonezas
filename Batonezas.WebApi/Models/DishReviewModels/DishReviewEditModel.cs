using Batonezas.WebApi.Models.PlaceModels;

namespace Batonezas.WebApi.Models.DishReviewModels
{
    public class DishReviewEditModel
    {
        public int Id { get; set; }

        public int? DishId { get; set; }

        public string DishName { get; set; }

        public int[] TagIdList { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }

        public string ImageUri { get; set; }

        public PlaceEditModel Place { get; set; }
    }
}