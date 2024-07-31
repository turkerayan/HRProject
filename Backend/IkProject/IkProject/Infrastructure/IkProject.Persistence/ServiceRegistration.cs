
using IkProject.Application.Repositories;
using IkProject.Application.UnitOfWorks;
using FluentValidation;
using IkProject.Application.Validators;
using IkProject.Domain.Identities;
using IkProject.Persistence.Context;
using IkProject.Persistence.Repositories;
using IkProject.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace IkProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<IkPorjectDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);

            }));


            services.AddIdentityCore<AppUser>()
                .AddRoles<AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IkPorjectDbContext>();

            services.AddIdentityCore<CompanyManger>()
                .AddRoles<AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IkPorjectDbContext>();

            services.AddIdentityCore<SiteManager>()
                .AddRoles<AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IkPorjectDbContext>();

            services.AddIdentityCore<Personal>()
                .AddRoles<AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IkPorjectDbContext>();

            services.AddIdentityCore<SiteManager>()
                .AddRoles<AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<IkPorjectDbContext>();


            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
