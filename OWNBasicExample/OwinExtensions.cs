using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OWNBasicExample
{
    public static class OwinExtensions
    {
        public static void UseDemoMiddleware(this IAppBuilder app)

        {

            app.Use<DemoMiddleware>();

        }
    }
}