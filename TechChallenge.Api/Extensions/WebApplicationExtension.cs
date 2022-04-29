using TechChallenge.Api.Abstractions;

namespace TechChallenge.Api.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplicationBuilder AddBuilderApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            return app;
        }

    }
}
