using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Business.DTOFolder.AutoMapperProfile;
using ProductMicroservice.Business.PictureServiceFolder;
using ProductMicroservice.Business.ProductServiceFolder;
using ProductMicroservice.Business.ProductSizeRegionServiceFolder;
using ProductMicroservice.Business.ProductSizeServiceFolder;
using ProductMicroservice.Business.ProductVariantPictureServiceFolder;
using ProductMicroservice.Business.ProductVariantServiceFolder;
using ProductMicroservice.Data;
using ProductMicroservice.Data.Repositories;
using ProductMicroservice.Data.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); // Controller'ların tanımlanması için gerekli

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductVariantService, ProductVariantService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IProductSizeService, ProductSizeService>();
builder.Services.AddScoped<IProductSizeRegionService, ProductSizeRegionService>();
builder.Services.AddScoped<IProductVariantPictureService, ProductVariantPictureService>();
builder.Services.AddDbContext<ProductContext>(options =>
	options.UseNpgsql(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

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