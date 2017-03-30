using System;

namespace Batonezas.WebApi.Models.ReviewModels
{
    public class ReviewEditModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }

        public int? ImageId { get; set; }

        public int PlaceId { get; set; }

        public bool IsValid { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}