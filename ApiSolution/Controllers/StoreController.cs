using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSolution.Data;
using ApiSolution.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreRepository storeRepository, ILogger<StoreController> logger)
        {
            _storeRepository = storeRepository;
            _logger = logger;
        }

        [HttpGet("All", Name = "GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return Ok(_storeRepository.GetProducts());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }

        }

        [HttpGet("ProductByName/{name}", Name = "GetProductsByName")]
        public ActionResult<Product> GetProductsByName(string name)
        {
            try
            {
                return _storeRepository.GetProductByName(name);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }

        }

        // GET api/values/5
        [HttpGet("ProductById/{id}", Name = "GetProductsById")]
        public ActionResult<Product> GetProductsById(int id)
        {
            try
            {
                return _storeRepository.GetProductById(id);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpPost]
        public void Post([FromBody] IEnumerable<Product> products)
        {
            try
            {
                _storeRepository.AddProducts(products);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to Insert products: {ex}");

            }
        }

        [HttpPost("CreateProduct/{product}", Name = "AddProduct")]
        public void AddProduct([FromBody] Product product)
        {            
            try
            {
                _storeRepository.AddProduct(product);               
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to Insert products: {ex}");

            }
        }

       
        [HttpPut("UpdateProduct/{id}")]
        public void Put(int id, Product model)
        {
            var editProduct = _storeRepository.GetProductById(id);

            editProduct.Id = model.Id;
            editProduct.ProductName = model.ProductName;
            editProduct.Price = model.Price;
            editProduct.ProductQty = model.ProductQty;
            editProduct.StockUpdatedOn = model.StockUpdatedOn;

            _storeRepository.EditProduct(editProduct);


        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete()
        {
            _storeRepository.RemoveAllProducts();            
        }
    }
}
