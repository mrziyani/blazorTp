using Microsoft.EntityFrameworkCore;
using Service;         // For MappingProfile, UserService, IJwtService, etc.
using DAL.Models;      // For ApplicationDbContext and the User class
using DAL.Repositories; // For IUserRepository and UserRepository
using Microsoft.OpenApi.Models;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service.Services;
using System.Text;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Enregistrer le DbContext en utilisant une chaîne de connexion définie dans appsettings.json
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Enregistrement des contrôleurs
            builder.Services.AddControllers();

            // Ajouter la configuration CORS : autoriser l'origine de Blazor WebAssembly
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorWasm", policy =>
                {
                    policy.WithOrigins("https://localhost:7027")  // Remplacez par l'URL de votre application Blazor si différente.
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Configuration de Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entrez le token JWT comme : Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {}
                    }
                });
            });

            // automap
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Insjec serv
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<Service.Services.UserService>();
            builder.Services.AddScoped<PostService>();
            
            builder.Services.AddScoped<IJwtService, JwtService>();

            // Configuration de l'authentification JWT
            var jwtKey = builder.Configuration["Jwt:Key"];
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Utiliser CORS avant l'authentification pour gérer les requêtes preflight
            app.UseCors("AllowBlazorWasm");

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
