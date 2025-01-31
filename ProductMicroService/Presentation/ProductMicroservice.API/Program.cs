using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductMicroservice.Business.DTOFolder.AutoMapperProfile;
using ProductMicroservice.Business.PictureServiceFolder;
using ProductMicroservice.Business.ProductServiceFolder;
using ProductMicroservice.Business.ProductSizeRegionServiceFolder;
using ProductMicroservice.Business.ProductSizeServiceFolder;
using ProductMicroservice.Business.ProductVariantServiceFolder;
using ProductMicroservice.Data;
using ProductMicroservice.Data.Repositories;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
	c.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers(); // Controller'ların tanımlanması için gerekli

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductVariantService, ProductVariantService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IProductSizeService, ProductSizeService>();
builder.Services.AddScoped<IProductSizeRegionService, ProductSizeRegionService>();
builder.Services.AddDbContext<ProductContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
	context.Database.EnsureCreated();
}
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();