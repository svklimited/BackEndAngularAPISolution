using ApiSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolution.Data
{
    public interface IStoreRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductByName(string productName);

        Product GetProductById(int productId);

        void SaveProducts();

        void AddProduct(Product product);

        void AddProducts(IEnumerable<Product> products);

        void RemoveAllProducts();

        void EditProduct(Product product);
       
    }
}
