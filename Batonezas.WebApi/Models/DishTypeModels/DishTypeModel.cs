using System;
using System.ComponentModel.DataAnnotations;

namespace Batonezas.WebApi.Models.DishTypeModels
{
    public class DishTypeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "")]
        public string Name { get; set; }

        public bool IsValid { get; set; }

        [Required]
        public int CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}