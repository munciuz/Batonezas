using System;

namespace Batonezas.WebApi.Models.ReviewModels
{
    public class ReviewListItemFilterModel
    {
        public bool IsValid { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}