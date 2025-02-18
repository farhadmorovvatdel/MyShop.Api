using Microsoft.EntityFrameworkCore;
using MyShop.Application.CategoryService;
using MyShop.Application.CategoryServices;
using MyShop.Application.RoleServices;
using MyShop.Application.UserService;
using MyShop.Domain.Interface;
using MyShop.Infrastructure.Context;
using MyShop.Infrastructure.Repositorservice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyShopContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#region Service And Repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryServiceInterface, Categoryservice>();
builder.Services.AddScoped<IUserInterface,UserRepository>();
builder.Services.AddScoped<IUserServiceInterface, UserService>();
builder.Services.AddScoped<IRoleInterface, RoleRepository>();
builder.Services.AddScoped<IRoleServiceInterface, RoleService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
