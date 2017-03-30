using System;

namespace Batonezas.WebApi.Models.PlaceModels
{
    public class PlaceEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsValid { get; set; }

        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string GPlaceId { get; set; }
    }
}