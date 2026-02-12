using Entity.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Contracts;
using Repository.EFCore;
using Services.Contracts;
using Services.Implementations;
using System.Text;
using System.Threading.RateLimiting;
namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {

        /* ------------------------------------------  S Q L   C O N T E X T  CONFIGURATION --------------------------------------*/
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
        /* ------------------------------------------  S Q L   C O N T E X T  CONFIGURATION --------------------------------------*/




        /* ------------------------------------------  R E P O S I T O R Y  M A N A G E R  CONFIGURATION --------------------------------------*/
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        /* ------------------------------------------  R E P O S I T O R Y  M A N A G E R  CONFIGURATION --------------------------------------*/




        /* ------------------------------------------  S E R V I C E S  CONFIGURATION --------------------------------------*/
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IServiceManager, ServiceManager>();

            if (FirebaseApp.DefaultInstance == null)
            {
               
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("/etc/secrets/firebase_service_account.json")
                });
            }

        }

        /* ------------------------------------------  S E R V I C E S  CONFIGURATION --------------------------------------*/




        /* ------------------------------------------  I D E N T I T Y  CONFIGURATION --------------------------------------*/
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

        /* ------------------------------------------  I D E N T I T Y  CONFIGURATION --------------------------------------*/



        /* ------------------------------------------  J S O N  W E B  T O K E N  CONFIGURATION --------------------------------------*/

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
        /* ------------------------------------------  J S O N  W E B  T O K E N  CONFIGURATION --------------------------------------*/




        /* ------------------------------------------ S W A G G E R  CONFIGURATION --------------------------------------*/

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

        /* ------------------------------------------ S W A G G E R  CONFIGURATION --------------------------------------*/




        /* ------------------------------------------ M E D I A T R CONFIGURATION --------------------------------------*/
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ServiceManager).Assembly));
            
        }
        /* ------------------------------------------ M E D I A T R CONFIGURATION --------------------------------------*/




        /* ------------------------------------------ R A T E  L I M I T I N G  CONFIGURATION --------------------------------------*/

        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter(policyName: "fixed", opt => 
                {
                    opt.PermitLimit = 10;
                    opt.Window = TimeSpan.FromSeconds(60);
                    opt.QueueLimit = 2;
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });
        }

        /* ------------------------------------------ R A T E  L I M I T I N G  CONFIGURATION --------------------------------------*/






        /* ------------------------------------------ C O R S CONFIGURATION --------------------------------------*/

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("X-Pagination");
                });
            });
        }

        /* ------------------------------------------ C O R S CONFIGURATION --------------------------------------*/


    }
}
