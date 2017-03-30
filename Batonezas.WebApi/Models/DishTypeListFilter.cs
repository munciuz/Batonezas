using System;

namespace Batonezas.WebApi.Models
{
    public class DishTypeListFilter
    {
        public string Name { get; set; }

        public bool IsValid { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}