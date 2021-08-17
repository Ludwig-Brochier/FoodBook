using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace DocFx
{
    public static class DocFxExtension
    {
        public static IApplicationBuilder UseDocFx(this IApplicationBuilder app, Action<DocFxSettings> config)
        {
            DocFxSettings settings = new DocFxSettings();

            if (config == null)
            {
                settings.rootPath = "/docfx";
            }

            else
            {
                config.Invoke(settings);
            }

            app.UseFileServer(new FileServerOptions
            {
                RequestPath = new PathString(settings.rootPath),
                FileProvider = new EmbeddedFileProvider(typeof(DocFxExtension).GetTypeInfo().Assembly, "DocFx._site")
            });

            return app;
        }
    }
}
