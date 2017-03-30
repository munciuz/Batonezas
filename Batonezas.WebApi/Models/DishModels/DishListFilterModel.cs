using System;

namespace Batonezas.WebApi.Models.DishModels
{
    public class DishListFilterModel
    {
        public string Name { get; set; }

        public bool IsValid { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}