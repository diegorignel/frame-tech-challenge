using TechChallenge.Api.Abstractions;

namespace TechChallenge.Api.Extensions
{
    public static class ModuleExtension
    {
        private static List<IModule> _modules = new List<IModule>();

        public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
        {
            _modules = DiscoverModules();

            _modules.ForEach(module => {
                module.RegisterModule(builder);
            });

            return builder;
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            _modules.ForEach(module =>
            {
                module.MapEndpoint(app);
            });

            return app;
        }

        private static List<IModule> DiscoverModules()
        {
            return typeof(IModule).Assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                .Select(Activator.CreateInstance)
                .Cast<IModule>()
                .ToList();
        }
    }
}
