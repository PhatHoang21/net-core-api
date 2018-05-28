using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSauce.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // Optional
        public void ConfigureServices(IServiceCollection services)
        {
            // Add service, it will be describle more detail in Configure method to tell how to use, config
            // services.AddSingleton<IComponent, ComponentB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Compulsory
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            // The order in which the Run and Use methods define RequestDelegates is significant,
            // as the runtime will execute each layer in precisely the same order as it was created. In the
            // preceding example, the first layer checks the request path of the incoming request. If it
            // matches / foo, it short-circuits the request and directly sends the appropriate response
            // back, else it executes next(), which is the next RequestDelegate layer in the pipeline
            // and so on.If the request manages to bypass all the previous Use layers, it eventually
            // executes Run, which sends the default response back
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/foo")
                {
                    await context.Response.WriteAsync($"Welcome to Foo");
                }
                else
                {
                    await next();
                }
            });
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/bar")
                {
                    await context.Response.WriteAsync($"Welcome to Bar");
                }
                else
                {
                    await next();
                }
            });
            app.Run(async (context) =>
            await context.Response.WriteAsync($"Welcome to the default")
            );
        }
    }
}
