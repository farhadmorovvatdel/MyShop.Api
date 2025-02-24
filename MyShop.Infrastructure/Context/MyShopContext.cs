using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Context
{
    public class MyShopContext:DbContext
    {
        public MyShopContext(DbContextOptions<MyShopContext> options):base(options) 
        {
            
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<Product> products { get; set; }    

        public DbSet<Order> orders { get; set; }

        public DbSet<OrderDetail> ordersDetail { get; set; }

        public DbSet<Like> likes { get; set; }

        public DbSet<Comment> comments { get; set; }


        public DbSet<DiscountCode> discounts { get; set; }
    }
}
