﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Batonezas.WebApi.Startup))]

namespace Batonezas.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}
