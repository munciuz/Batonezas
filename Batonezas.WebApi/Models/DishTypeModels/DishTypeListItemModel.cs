using System;

namespace Batonezas.WebApi.Models.DishTypeModels
{
    public class DishTypeListItemModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsValid { get; set; }
        
        public string CreatedByUser { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}