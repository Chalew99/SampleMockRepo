using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OWNBasicExample
{
    using AppFunc = Func<IDictionary<string, object>, Task>;



    public class DemoMiddleware

    {

        AppFunc _next;

        public DemoMiddleware(AppFunc next)

        {

            _next = next;

        }

        public async Task Invoke(IDictionary<string, object> environment)

        {

            using (var writer = new StreamWriter(environment["owin.ResponseBody"] as Stream))

            {

                await writer.WriteAsync("<h3>MW3: Hello from 3rd Middleware class method!</h3>");

            }

            await _next.Invoke(environment);

        }

    }
}