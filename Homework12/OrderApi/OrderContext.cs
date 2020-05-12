using Microsoft.EntityFrameworkCore;
using OrderApi;

public class OrderContext:DbContext
{
	public OrderContext(DbContextOptions<OrderContext> options)
		:base(options){
		this.Database.EnsureCreated();
	}
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Commodity> Commodities { get; set; }
	public DbSet<Customer> Customers { get; set; }
}
