using AutoMapper;
using ids.core.Interfaces;
using ids.core.Models;
using ids.core.Repositories;
using ids.services;
using ids.services.Interfaces;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IEventService, EventService>();

builder.Services.AddTransient<IEventGuidesService, EventGuidesService>();
builder.Services.AddTransient<IEventGuidesRepository, EventGuidesRepository>();

builder.Services.AddTransient<IEventMembersService, EventMembersService>();
builder.Services.AddTransient<IEventMembersRepository, EventMembersRepository>();

builder.Services.AddTransient<IGuideService, GuideService>();
builder.Services.AddTransient<IGuideRepository, GuideRepository>();

builder.Services.AddTransient<ILookupService, LookupService>();
builder.Services.AddTransient<ILookupRepository, LookupRepository>();

builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();

builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IUserRoleRepository, UserRoleRepository>();

builder.Services.AddDbContext<ActivityClubPortalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM Central Mobile", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT containing userid claim",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    //var security =
    //   new OpenApiSecurityRequirement
    //   {
    //       {
    //           new OpenApiSecurityScheme
    //           {
    //               Reference = new OpenApiReference
    //               {
    //                   Id = "Bearer",
    //                   Type = ReferenceType.SecurityScheme
    //               },
    //               UnresolvedReference = true
    //           },
    //           new List<string>()
    //       }
    //   };
    //options.AddSecurityRequirement(security);
});

builder.Services.AddAuthentication("Bearer").AddJwtBearer
        (options =>
        {

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("JWT:Token").Value!))
            };
        });

builder.Services.AddAuthorization();





builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
