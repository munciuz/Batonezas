﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using AutoMapper;
using Batonezas.DataAccess;
using Batonezas.WebApi.Infrastructure.Constants;
using Batonezas.WebApi.Infrastructure.Helpers;
using Batonezas.WebApi.Models.TagModels;
using Batonezas.WebApi.Repositories;

namespace Batonezas.WebApi.Services
{
    public interface IImageService
    {
        int CreateImage(string imageUri);
        void CreateImageFile(int id, byte[] bytes);
        string GetImagePath(int id);
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
            //imageUri = @"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAIBAQIBAQICAgICAgICAwUDAwMDAwYEBAMFBwYHBwcGBwcICQsJCAgKCAcHCg0KCgsMDAwMBwkODw0MDgsMDAz/2wBDAQICAgMDAwYDAwYMCAcIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAz/wAARCAADAAMDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9NfCFiPDmjG0tZrxYFubiQCS6klILzu7fM7E4yxwM4AwBgACiiivr8tyLLZ4OlOeHg24xbbhG7dl5H5ZU4qzuU3KWMqtt/wDPyf8Amf/Z";

            var bytes = Convert.FromBase64String(imageUri);

            var image = new Image
            {
                Original = bytes,
                Preview = bytes,
                CreatedDateTime = DateTime.Now,
                CreatedByUserId = UserHelper.GetCurrentUserId(),
                IsValid = true
            };

            imageRepository.Insert(image);

            CreateImageFile(image.Id, bytes);

            return image.Id;
        }

        public string GetImagePath(int id)
        {
            var path = BatonezasConstants.BaseUrl + BatonezasConstants.PhotoPath + "/" + id + ".jpeg";

            return path;
        }

        public void CreateImageFile(int id, byte[] bytes)
        {
            var path = HttpContext.Current.Server.MapPath(BatonezasConstants.PhotoUploadPath);

            CreateDirectory(path);

            string imageName = id + ".jpeg";

            string imgPath = Path.Combine(path, imageName);

            File.WriteAllBytes(imgPath, bytes);
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}