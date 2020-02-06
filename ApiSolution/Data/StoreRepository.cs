using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSolution.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiSolution.Data
{
    //I Would like to create repositories based on generics, 
    //which will eliminated the repetition of coding against different database repository.
    //May be I'll refactor the code after achieving the initial objectives if time permits. 
    //This code can also be created, an aysn operation.
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _ctx;

        public StoreRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            _ctx.AddRange(products);
            _ctx.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _ctx.Products.Where(cn => cn.Id == productId).FirstOrDefault();
        }

        public Product GetProductByName(string productName)
        {
            return _ctx.Products.FirstOrDefault(x => x.ProductName == productName);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products.OrderBy(p => p.StockUpdatedOn.Date).ThenBy(p => p.StockUpdatedOn.Month).ThenBy(p => p.StockUpdatedOn.Year).ToList();
        }

        public void RemoveAllProducts()
        {
            _ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE [Products]");           
        }

        public void SaveProducts()
        {
            _ctx.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            _ctx.Entry<Product>(product).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            _ctx.Add(product);
            _ctx.SaveChanges();
        }
    }
}
