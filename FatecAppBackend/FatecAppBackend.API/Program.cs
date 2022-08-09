using FatecAppBackend.Domain.Handlers.Authentication;
using FatecAppBackend.Domain.Handlers.College;
using FatecAppBackend.Domain.Handlers.Event;
using FatecAppBackend.Domain.Handlers.Participant;
using FatecAppBackend.Domain.Handlers.User;
using FatecAppBackend.Domain.Handlers.UserCollege;
using FatecAppBackend.Domain.Repositories;
using FatecAppBackend.Infra.Data.Contexts;
using FatecAppBackend.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Services

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

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

#endregion

#region Authentication
builder.Services.AddTransient<SignInHandler, SignInHandler>();

#endregion

#region User handlers
builder.Services.AddTransient<CreateUserHandler, CreateUserHandler>();
builder.Services.AddTransient<GetByIdHandler, GetByIdHandler>();
builder.Services.AddTransient<GetUserByEmailHandler, GetUserByEmailHandler>();
builder.Services.AddTransient<UpdateUserGenderHandler, UpdateUserGenderHandler>();
builder.Services.AddTransient<UpdateUserIdentityDocumentPhotoHandler, UpdateUserIdentityDocumentPhotoHandler>();
builder.Services.AddTransient<UpdateUserIdentityDocumentNumberHandler, UpdateUserIdentityDocumentNumberHandler>();
builder.Services.AddTransient<UpdateUserNameHandler, UpdateUserNameHandler>();
builder.Services.AddTransient<UpdateUserPasswordHandler, UpdateUserPasswordHandler>();
builder.Services.AddTransient<UpdateUserPhoneNumberHandler, UpdateUserPhoneNumberHandler>();
builder.Services.AddTransient<UpdateUserPhotoHandler, UpdateUserPhotoHandler>();
builder.Services.AddTransient<UpdateUserValidatedUserHandler, UpdateUserValidatedUserHandler>();


#endregion

#region College handlers
builder.Services.AddTransient<CreateCollegeHandler, CreateCollegeHandler>();
builder.Services.AddTransient<GetCollegeByIdHandler, GetCollegeByIdHandler>();
builder.Services.AddTransient<RemoveCollegeHandler, RemoveCollegeHandler>();
builder.Services.AddTransient<UpdateCollegeCourseHandler, UpdateCollegeCourseHandler>();
builder.Services.AddTransient<UpdateCollegeLocalizationHandler, UpdateCollegeLocalizationHandler>();
builder.Services.AddTransient<UpdateCollegeNameHandler, UpdateCollegeNameHandler>();
builder.Services.AddTransient<UpdateCollegeTimeHandler, UpdateCollegeTimeHandler>();

#endregion

#region Event handlers
builder.Services.AddTransient<CreateEventHandler, CreateEventHandler>();
builder.Services.AddTransient<GetEventByIdHandler, GetEventByIdHandler>();
builder.Services.AddTransient<RemoveEventHandler, RemoveEventHandler>();
builder.Services.AddTransient<UpdateEventFromHandler, UpdateEventFromHandler>();
builder.Services.AddTransient<UpdateEventOnlyWomenHandler, UpdateEventOnlyWomenHandler>();
builder.Services.AddTransient<UpdateEventRouteHandler, UpdateEventRouteHandler>();
builder.Services.AddTransient<UpdateEventStatusHandler, UpdateEventStatusHandler>();
builder.Services.AddTransient<UpdateEventTimeToGoHandler, UpdateEventTimeToGoHandler>();
builder.Services.AddTransient<UpdateEventToHandler, UpdateEventToHandler>();


#endregion

#region UserCollege handlers
builder.Services.AddTransient<CreateUserCollegeHandler, CreateUserCollegeHandler>();
builder.Services.AddTransient<GetUserCollegeByIdHandler, GetUserCollegeByIdHandler>();
builder.Services.AddTransient<RemoveUserCollegeHandler, RemoveUserCollegeHandler>();
builder.Services.AddTransient<UpdateUserCollegeGraduationDateHandler, UpdateUserCollegeGraduationDateHandler>();
builder.Services.AddTransient<UpdateUserCollegeProofDocumentHandler, UpdateUserCollegeProofDocumentHandler>();
builder.Services.AddTransient<UpdateUserCollegeStudentNumberHandler, UpdateUserCollegeStudentNumberHandler>();
builder.Services.AddTransient<UpdateUserCollegeValidatedDocumentHandler, UpdateUserCollegeValidatedDocumentHandler>();
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
