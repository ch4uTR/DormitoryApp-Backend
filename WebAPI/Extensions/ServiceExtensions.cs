using Entity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Contracts;
using Repository.EFCore;
using Services.Contracts;
using Services.Implementations;
using System.Text;
namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) {

            var provider = configuration["DatabaseProvider"];
            
            services.AddDbContext<PostgresRepositoryContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"), 
                    x => x.MigrationsAssembly("Repository")); });
            
            services.AddDbContext<MsSqlRepositoryContext>(options =>
            { options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"), 
                x => x.MigrationsAssembly("Repository")); });


            services.AddScoped<RepositoryContext>(providerService => { 

            if (provider?.Equals("Postgres", StringComparison.OrdinalIgnoreCase) == true)
                {
                    return providerService.GetRequiredService<PostgresRepositoryContext>();
                }

            return providerService.GetRequiredService<MsSqlRepositoryContext>();


            });

        }
        

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IServiceManager, ServiceManager>();

        }

        public static void ConfigureIdentity(this IServiceCollection services,  IConfiguration configuration) {

            var provider = configuration["DatabaseProvider"];

            var builder = services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 3;

            });

            if (provider?.Equals("Postgres", StringComparison.OrdinalIgnoreCase) == true)
            {
                builder.AddEntityFrameworkStores<PostgresRepositoryContext>();
            }
            else
            {
                builder.AddEntityFrameworkStores<MsSqlRepositoryContext>();
            }
           
            builder.AddDefaultTokenProviders();
            }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["key"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        } 
    
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Lütfen sadece tokenı yapıştırın. Örn: eyJhbG...",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });


            });
        }
    
    
    
    
    }
}
