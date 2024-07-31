using FluentValidation;
using IkProject.Application.Expections;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Beheviors;

namespace IkProject.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddExceptionHandler<ExpectionMiddelware>();   

            services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));


            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

        }
    }
}
