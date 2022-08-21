
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
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Services

    builder.Services.AddControllers()
                    .AddJsonOptions(x =>
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen(c => {
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        c.IgnoreObsoleteActions();
        c.IgnoreObsoleteProperties();
        c.CustomSchemaIds(type => type.FullName);
    });

builder.Services.AddDbContext<FatecAppBackendContext>(
        x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
