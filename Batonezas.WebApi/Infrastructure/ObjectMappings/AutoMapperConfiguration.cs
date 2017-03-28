using AutoMapper;

namespace Batonezas.WebApi.Infrastructure.ObjectMappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperModelsProfile>();
            });
        }
    }
}