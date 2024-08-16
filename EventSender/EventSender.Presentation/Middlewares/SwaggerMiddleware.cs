using Swashbuckle.AspNetCore.SwaggerUI;

namespace EventSender.WebApi.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IConfiguration configuration, string SwaggerConfigName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string endPoint = configuration[$"{SwaggerConfigName}:EndPoint"];
                string title = configuration[$"{SwaggerConfigName}:Title"];
                c.SwaggerEndpoint(endPoint, title);
                c.DocumentTitle = $"{title} Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
