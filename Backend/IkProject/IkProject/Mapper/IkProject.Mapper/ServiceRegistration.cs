using IkProject.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;


namespace IkProject.Mapper
{
    public static class ServiceRegistration
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
