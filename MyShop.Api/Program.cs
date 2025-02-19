using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application.CategoryService;
using MyShop.Application.CategoryServices;
using MyShop.Application.JwtService;
using MyShop.Application.RoleServices;
using MyShop.Application.UserService;
using MyShop.Domain.Interface;
using MyShop.Domain.Jwt;
using MyShop.Infrastructure.Context;
using MyShop.Infrastructure.Repositorservice;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Authorization
builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("UserRole", policy => policy.RequireClaim(ClaimTypes.Role,"User"));
    op.AddPolicy("AdminRole", policy => policy.RequireClaim(ClaimTypes.Role,"Admin"));
});
#endregion
builder.Services.AddDbContext<MyShopContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var jwtSettings = builder.Configuration.GetSection("JwtSetting").Get<JwtSetting>();
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));
#region Service And Repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryServiceInterface, Categoryservice>();
builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<IUserServiceInterface, UserService>();
builder.Services.AddScoped<IRoleInterface, RoleRepository>();
builder.Services.AddScoped<IRoleServiceInterface, RoleService>();
builder.Services.AddScoped<IJwtService, jwtservice>();
#endregion

#region Authentication
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
#endregion
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
