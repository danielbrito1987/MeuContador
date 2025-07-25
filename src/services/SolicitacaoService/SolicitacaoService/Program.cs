using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SolicitacaoService.Application.Interfaces.Repositories;
using SolicitacaoService.Application.Interfaces.Services;
using SolicitacaoService.Application.Services;
using SolicitacaoService.Infraestructure.Context;
using SolicitacaoService.Infraestructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<SolicitacaoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
builder.Services.AddScoped<ISolicitacaoService, SolicitacaoService.Application.Services.SolicitacaoService>();
builder.Services.AddScoped<IMensagemSolicitacaoRepository, MensagemSolicitacaoRepository>();
builder.Services.AddScoped<IMensagemSolicitacaoService, MensagemSolicitacaoService>();

// JWT
var jwtSection = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSection["Key"]!);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ClienteService", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Insira o token JWT."
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
