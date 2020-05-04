using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OrderSystemNew;

namespace OrderSyetemNew
{
    public class OrderContext:DbContext
    {
        public OrderContext():base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

}
