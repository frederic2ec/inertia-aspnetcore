using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Inertia.AspNetCore
{
    public static class Configure
    {
        public static IMvcBuilder AddInertia(this IMvcBuilder app)
        {
            app.AddRazorRuntimeCompilation(opts =>
            {
                opts.FileProviders.Add(
                    new EmbeddedFileProvider(typeof(Configure).GetTypeInfo().Assembly));
            });

            return app;
        }
    }
}