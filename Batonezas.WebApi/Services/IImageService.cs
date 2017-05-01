using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IImageService
    {
        int CreateImage(string imageUri);
    }

    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public int CreateImage(string imageUri)
        {
            var bytes = Convert.FromBase64String(imageUri);

            var image = new Image
            {
                Original = bytes,
                Preview = bytes,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = 1,
                IsValid = true
            };

            imageRepository.Insert(image);

            return image.Id;
        }
    }
}