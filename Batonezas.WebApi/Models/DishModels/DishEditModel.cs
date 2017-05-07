using System;
using Batonezas.WebApi.Models.TagModels;

namespace Batonezas.WebApi.Models.DishModels
{
    public class DishEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TagListItemModel[] SelectedTags { get; set; }

        public TagListItemModel[] AllTags { get; set; }

        public bool IsValid { get; set; }

        public bool IsConfirmed { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}