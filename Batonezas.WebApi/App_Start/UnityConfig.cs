using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System.Reflection;

namespace Batonezas.WebApi
{
    public static class UnityConfig
    {
        private static IUnityContainer container;

        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
        }

        public static void RegisterComponents()
        {
            if (container == null)
            {
                container = new UnityContainer();
            }

            var assemblies = AssembliesToRegisterTypes();

            container.RegisterTypes(
                AllClasses.FromAssemblies(assemblies),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve);

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static List<Assembly> AssembliesToRegisterTypes()
        {
            return new List<Assembly>
            {
                Assembly.Load("Batonezas.WebApi"),
            };
        }
    }
}