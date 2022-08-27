
using FatecAppBackend.Domain.Handlers.Commands.Authentication;
using FatecAppBackend.Domain.Handlers.Commands.College;
using FatecAppBackend.Domain.Handlers.Commands.Event;
using FatecAppBackend.Domain.Handlers.Commands.Participant;
using FatecAppBackend.Domain.Handlers.Commands.User;
using FatecAppBackend.Domain.Handlers.Commands.UserCollege;
using FatecAppBackend.Domain.Handlers.Queries.College;
using FatecAppBackend.Domain.Handlers.Queries.Event;
using FatecAppBackend.Domain.Handlers.Queries.Participant;
using FatecAppBackend.Domain.Handlers.Queries.User;
using FatecAppBackend.Domain.Handlers.Queries.UserCollege;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Infra.Data.Contexts;
using FatecAppBackend.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Controllers
builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddEndpointsApiExplorer();

// Swagger
builder.Services
    .AddSwaggerGen(c =>
    {
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        c.IgnoreObsoleteActions();
        c.IgnoreObsoleteProperties();
        c.CustomSchemaIds(type => type.FullName);
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "FatecApp API",
            Description = "Documentation of Api's endpoints",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "João Vitor",
                Email = "jovioli.dev04@gmail.com",
                Url = new Uri("https://github.com/JoVi0li"),
            },
            License = new OpenApiLicense
            {
                Name = "Nothing",
                Url = new Uri("https://example.com/license"),
            }
        });

        c.AddSecurityDefinition("Bearer Token", new OpenApiSecurityScheme()
        {
            Name = "Bearer ",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });


// Database
builder.Services
    .AddDbContext<FatecAppBackendContext>(x =>
        x.UseSqlServer(builder.Configuration.GetConnectionString("FatecAppDBConnection"))
    );

// Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "FatecAppBackend",
            ValidAudience = "FatecAppMobile",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fatec-app-key-jwt-16-25-05-08-20-22"))
        };
    });

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
    );
});

#endregion

#region Dependencies

#region Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserCollegeRepository, UserCollegeRepository>();
builder.Services.AddTransient<ICollegeRepository, CollegeRepository>();
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IParticipantRepository, ParticipantRepository>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();

#endregion

#region Authentication
builder.Services.AddTransient<SignInHandler, SignInHandler>();

#endregion

#region User handlers
builder.Services.AddTransient<CreateUserHandler, CreateUserHandler>();
builder.Services.AddTransient<GetUserByIdHandler, GetUserByIdHandler>();
builder.Services.AddTransient<GetUserByEmailHandler, GetUserByEmailHandler>();
builder.Services.AddTransient<GetUserByNameHandler, GetUserByNameHandler>();
builder.Services.AddTransient<GetUserHandler, GetUserHandler>();
builder.Services.AddTransient<RemoveUserHandler, RemoveUserHandler>();
builder.Services.AddTransient<UpdateUserHandler, UpdateUserHandler>();

#endregion

#region College handlers
builder.Services.AddTransient<CreateCollegeHandler, CreateCollegeHandler>();
builder.Services.AddTransient<GetCollegeByIdHandler, GetCollegeByIdHandler>();
builder.Services.AddTransient<GetCollegeHandler, GetCollegeHandler>();
builder.Services.AddTransient<RemoveCollegeHandler, RemoveCollegeHandler>();
builder.Services.AddTransient<UpdateCollegeHandler, UpdateCollegeHandler>();

#endregion

#region Event handlers
builder.Services.AddTransient<CreateEventHandler, CreateEventHandler>();
builder.Services.AddTransient<GetEventByIdHandler, GetEventByIdHandler>();
builder.Services.AddTransient<RemoveEventHandler, RemoveEventHandler>();
builder.Services.AddTransient<UpdateEventHandler, UpdateEventHandler>();
builder.Services.AddTransient<GetEventHandler, GetEventHandler>();
#endregion

#region UserCollege handlers
builder.Services.AddTransient<CreateUserCollegeHandler, CreateUserCollegeHandler>();
builder.Services.AddTransient<GetUserCollegeByIdHandler, GetUserCollegeByIdHandler>();
builder.Services.AddTransient<RemoveUserCollegeHandler, RemoveUserCollegeHandler>();
builder.Services.AddTransient<GetUserCollegeByCollegeIdHandler, GetUserCollegeByCollegeIdHandler>();
builder.Services.AddTransient<GetUserCollegeByUserIdHandler, GetUserCollegeByUserIdHandler>();
builder.Services.AddTransient<GetUserCollegeHandler, GetUserCollegeHandler>();
builder.Services.AddTransient<UpdateUserCollegeHandler, UpdateUserCollegeHandler>();

#endregion

#region Participant handlers
builder.Services.AddTransient<CreateParticipantHandler, CreateParticipantHandler>();
builder.Services.AddTransient<GetParticipantByIdHandler, GetParticipantByIdHandler>();
builder.Services.AddTransient<GetParticipantByEventIdHandler, GetParticipantByEventIdHandler>();
builder.Services.AddTransient<GetParticipantByUserCollegeIdHandler, GetParticipantByUserCollegeIdHandler>();
builder.Services.AddTransient<RemoveParticipantHandler, RemoveParticipantHandler>();
#endregion

#endregion

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.UseSwagger(options => { options.SerializeAsV2 = true; });

app.UseSwaggerUI();

app.Run();
