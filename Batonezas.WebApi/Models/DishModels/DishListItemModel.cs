using System;

namespace Batonezas.WebApi.Models.DishModels
{
    public class DishListItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsValid { get; set; }

        public bool IsConfirmed { get; set; }

        public string CreatedByUser { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}