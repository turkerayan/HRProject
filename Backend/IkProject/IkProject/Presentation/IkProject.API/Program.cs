using IkProject.Infrastructure;
using IkProject.Persistence;
using Microsoft.OpenApi.Models;
using IkProject.Application;
using IkProject.Application.Abstractions.Services;
using IkProject.Infrastructure.Services;
using IkProject.Mapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplication();
builder.Services.AddMapperService();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.MaxDepth = 1;
    });




builder.Services.AddTransient<IMailServices, MailService>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddProblemDetails();

builder.Services.AddAuthorization(cfg =>
    {
        cfg.AddPolicy("CompanyManagerRole", policyBuilder => policyBuilder.RequireRole("CompanyManager"));
        cfg.AddPolicy("PersonalRole", policyBuilder => policyBuilder.RequireRole("Personal"));
        cfg.AddPolicy("SiteManagerRole", policyBuilder => policyBuilder.RequireRole("SiteManager"));

        cfg.AddPolicy("CompanyManagerOrPersonal", policyBuilder =>
        {
            policyBuilder.RequireRole("CompanyManager", "Personal");
        });

        cfg.AddPolicy("CompanyManagerOrPersonalOrSiteManager", policyBuilder =>
        {
            policyBuilder.RequireRole("CompanyManager", "Personal", "SiteManager");
        });

    });

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Allow", policy =>
    {
        policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
    });
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IkProject API", Version = "v1", Description = "IkProject API swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();

app.UseSwaggerUI();

//app.ConfigureExpectionHandleingMiddleware();

app.UseHttpsRedirection();

app.UseCors("Allow");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();



app.UseExceptionHandler();

app.MapControllers();

app.Run();
