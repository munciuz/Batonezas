using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Batonezas.WebApi.Infrastructure;
using Batonezas.WebApi.Repositories;
using Microsoft.AspNet.Identity;

namespace Batonezas.WebApi.Controllers
{
    public class ImageController : ApiControllerBase
    {
        private readonly ImageRepository imageRepository;

        public ImageController(ImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult GetImage(int imageId)
        {
            var image = imageRepository.Get(imageId);
            var imageBytes = image.Original;

            //return new FileContentResult(imageBytes, "image/png");
            return new FileContentResult(imageBytes, "image/jpeg");
        }
    }
}