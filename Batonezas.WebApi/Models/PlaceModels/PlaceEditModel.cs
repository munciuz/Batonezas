using System;

namespace Batonezas.WebApi.Models.PlaceModels
{
    public class PlaceEditModel
    {
        public int Id { get; set; }

        public string GId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsValid { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string[] GTypes { get; set; }
    }
}