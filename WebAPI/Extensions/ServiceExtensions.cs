using Entity.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
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
        
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IServiceManager, ServiceManager>();

            if (FirebaseApp.DefaultInstance == null)
            {
                var firebaseSection = configuration.GetSection("FirebaseJson");

                var firebaseJson = System.Text.Json.JsonSerializer.Serialize(new
                {
                    type = firebaseSection["type"],
                    project_id = firebaseSection["project_id"],
                    private_key_id = firebaseSection["private_key_id"],
                    private_key = firebaseSection["private_key"]?.Replace("\\n", "\n"),
                    client_email = firebaseSection["client_email"],
                    client_id = firebaseSection["client_id"],
                    auth_uri = firebaseSection["auth_uri"],
                    token_uri = firebaseSection["token_uri"],
                    auth_provider_x509_cert_url = firebaseSection["auth_provider_x509_cert_url"],
                    client_x509_cert_url = firebaseSection["client_x509_cert_url"]
                });

                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(firebaseJson)
                });
            }

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
        
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ServiceManager).Assembly));
            
        }
    
    
    
    }
}
