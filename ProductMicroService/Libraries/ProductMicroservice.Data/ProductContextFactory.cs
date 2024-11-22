using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductMicroservice.Data;

public class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
{
	public ProductContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
		optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Product;Username=postgres;Password=postgres",
			b => b.MigrationsAssembly("ProductMicroservice.Data"));

		return new ProductContext(optionsBuilder.Options);
	}
}
