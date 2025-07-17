using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Mappings;
using EstoqueLoja.API.Models;
using EstoqueLoja.API.Repositorys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EstoqueLojaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:secretKey"]))
    };

    options.Events = new JwtBearerEvents {
        OnMessageReceived = context => {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            if(!string.IsNullOrEmpty(token) && !token.StartsWith("Bearer")) {
                context.Token = token;
            }
            return Task.CompletedTask;
        },

        OnAuthenticationFailed = context => {
            Console.WriteLine("Token Inválido: ", context.Exception.Message);
            return Task.CompletedTask;
        },

        OnTokenValidated = context => {
            Console.WriteLine("Token Válido: ", context.SecurityToken);
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo() {
        Version = "v1",
        Title = "Admin.API",
        Description = "Api de Admin"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Coloque apenas o JWToken para autorizar"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement { 
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<ILojaRepository, LojaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IItensEstoqueRepository, ItensEstoqueRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
