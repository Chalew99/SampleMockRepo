using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(OWNBasicExample.Startup))]
namespace OWNBasicExample
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup

    {
        public void Configuration(IAppBuilder app)

        {
            app.Use(new Func<AppFunc, AppFunc>(next => (async context =>

            {
                using (var writer = new StreamWriter(context["owin.ResponseBody"] as Stream))
                {
                    await writer.WriteAsync("<h1>MW1: Hello from 1St inline Method middleware!</h1>");
                }
                await next.Invoke(context);
            })));

            var middleware = new Func<AppFunc, AppFunc>(MyMiddleWare);
            app.Use(middleware);
            app.Use<DemoMiddleware>();
            app.UseDemoMiddleware();
        }

    public AppFunc MyMiddleWare(AppFunc next)
            {
                AppFunc appFunc = async (IDictionary<string, object> environment) =>
                {
                    var response = environment["owin.ResponseBody"] as Stream;
                    using (var writer = new StreamWriter(response))
                    {
                        await writer.WriteAsync("<h2>MW2: Hello from 2nd Explicit Method middleware!</h2>");
                    }
                    await next.Invoke(environment);
                };
                return appFunc;

            } 


    }
}