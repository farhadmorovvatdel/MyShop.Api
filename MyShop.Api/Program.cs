using Autofac.Extensions.DependencyInjection;
using Autofac;
using FluentValidation;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application.CategoryService;
using MyShop.Application.CategoryServices;
using MyShop.Application.CommentServices;
using MyShop.Application.DiscountServices;
using MyShop.Application.FluentValidation;
using MyShop.Application.JwtService;
using MyShop.Application.LikeServices;
using MyShop.Application.OrderServices;
using MyShop.Application.ProductServices;
using MyShop.Application.RatesServices;
using MyShop.Application.RoleServices;
using MyShop.Application.UserService;
using MyShop.Application.Vm.Product;
using MyShop.Domain.Interface;
using MyShop.Domain.Jwt;
using MyShop.Infrastructure.Context;
using MyShop.Infrastructure.Repositorservice;
using Newtonsoft.Json;
using System.Reflection;
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
    //op.AddPolicy("UserRole", policy => policy.RequireRole("User"));
    op.AddPolicy("UserRole", p => p.RequireClaim(ClaimTypes.Role, "User"));
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
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<CategoryServiceInterface, Categoryservice>();
//builder.Services.AddScoped<IUserInterface, UserRepository>();
//builder.Services.AddScoped<IUserServiceInterface, UserService>();
//builder.Services.AddScoped<IRoleInterface, RoleRepository>();
//builder.Services.AddScoped<IRoleServiceInterface, RoleService>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IOrderInterface,OrderRepository>();
//builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IJwtService, jwtservice>();
//builder.Services.AddScoped<ILikeRepository,LikeRepository>();
//builder.Services.AddScoped<ILIkeService,LikeService>();
//builder.Services.AddScoped<ICommentRepository, CommentRepository>();
//builder.Services.AddScoped<ICommentService, CommentService>();
//builder.Services.AddScoped<IDiscountRepository,DiscountRepository>();
//builder.Services.AddScoped<IDiscountService,DiscountService>();
//builder.Services.AddScoped<IRateRepository, RateRepository>();
//builder.Services.AddScoped<IRateService, RateService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(c =>
{
    var assembley = Assembly.GetExecutingAssembly();
    c.RegisterAssemblyTypes(assembley).AsImplementedInterfaces().InstancePerLifetimeScope();
    c.RegisterAssemblyTypes(Assembly.Load("MyShop.Domain"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    c.RegisterAssemblyTypes(Assembly.Load("MyShop.Infrastructure"))
       .AsImplementedInterfaces()
       .InstancePerLifetimeScope();
    c.RegisterAssemblyTypes(Assembly.Load("MyShop.Application"))
     .AsImplementedInterfaces()
     .InstancePerLifetimeScope();
    c.RegisterAssemblyTypes(Assembly.Load("MyShop.Api"))
     .AsImplementedInterfaces()
     .InstancePerLifetimeScope();
});
#endregion
builder.Services.AddHttpContextAccessor();
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

//builder.Services.AddHangfire(op =>
//{
//    op.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
//    .UseSimpleAssemblyNameTypeSerializer().
//    UseRecommendedSerializerSettings().
//    UseSqlServerStorage(builder.Configuration.GetConnectionString("HangFireConnection"));
//});
//builder.Services.AddHangfireServer();


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
//app.UseHangfireDashboard();

//RecurringJob.AddOrUpdate<ProductService>("delete-Orders", op => op.DeleteProductById(5), "*/1 * * * *");
app.Run();
