using System;

namespace Batonezas.WebApi.Models.PlaceModels
{
    public class PlaceListItemModel
    {
        public bool Name { get; set; }

        public bool IsValid { get; set; }

        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public string CreatedByUserName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string GPlaceId { get; set; }
    }
}