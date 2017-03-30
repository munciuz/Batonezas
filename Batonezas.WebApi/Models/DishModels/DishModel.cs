using System;

namespace Batonezas.WebApi.Models.DishModels
{
    public class DishModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DishTypeId { get; set; }

        public bool IsValid { get; set; }

        public bool IsConfirmed { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}