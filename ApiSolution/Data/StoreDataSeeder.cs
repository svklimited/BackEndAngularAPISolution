using ApiSolution.Data;
using ApiSolution.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolution.Data
{
    public class StoreDataSeeder
    {
        private readonly DataContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public StoreDataSeeder(DataContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void seed()
        {
            _ctx.Database.EnsureCreated();

            if(!_ctx.Products.Any())
            {
                var productSeedData = new List<Product>
                {
                    new Product()
                    {                    
                     ProductName = "banana",
                     Price = 0.29m,
                     ProductQty = 20,
                     StockUpdatedOn = new DateTime(2014,04,11)
                    },
                    new Product()
                    {                    
                     ProductName = "honeydew melon",
                     Price = 1.01m,
                     ProductQty = 3,
                     StockUpdatedOn = new DateTime(2014,04,29)
                    },
                     new Product()
                    {
                     ProductName = "watermelon",
                     Price = 1.54m,
                     ProductQty = 4,
                     StockUpdatedOn = new DateTime(2014,04,30)
                    },
                    new Product()
                    {
                     ProductName = "apple",
                     Price = 0.41m,
                     ProductQty = 241,
                     StockUpdatedOn = new DateTime(2014,03,11)
                    },
                    new Product()
                    {
                     ProductName = "pear",
                     Price = 0.64m,
                     ProductQty = 100,
                     StockUpdatedOn = new DateTime(2014,03,14)
                    },
                    new Product()
                    {
                     ProductName = "kumquat",
                     Price = 2.04m,
                     ProductQty = 1,
                     StockUpdatedOn = new DateTime(2014,07,14)
                    }

                };

                _ctx.Products.AddRange(productSeedData);

                _ctx.SaveChanges();
            }
        }
    }
}
