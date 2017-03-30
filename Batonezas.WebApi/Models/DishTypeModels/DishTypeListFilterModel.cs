using System;

namespace Batonezas.WebApi.Models.DishTypeModels
{
    public class DishTypeListFilterModel
    {
        public string Name { get; set; }

        public bool IsValid { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}