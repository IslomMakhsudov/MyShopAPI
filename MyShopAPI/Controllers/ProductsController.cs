using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopAPI.Models;

namespace MyShopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Description = "Description for product 1", Price = 5.59m },
        new Product { Id = 2, Name = "Product 2", Description = "Description for product 2", Price = 9.89m },
        new Product { Id = 3, Name = "Product 3", Description = "Description for product 3", Price = 15.69m }
    };

        private static List<Order> _orders = new List<Order>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("order")]
        public IActionResult Order([FromBody] Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
            return Ok();
        }

        [HttpDelete("order/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
                return Ok();
            }
            return NotFound();
        }
    }
}
