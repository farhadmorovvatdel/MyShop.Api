﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Category>
    }
}
