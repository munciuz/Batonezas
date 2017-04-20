using System;

namespace Batonezas.WebApi.Models.TagModels
{
    public class TagEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsValid { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}