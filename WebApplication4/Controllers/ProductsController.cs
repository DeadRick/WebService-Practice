using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static List<Product> products = new List<Product>(new[] {
        new Product() { Id = 1, Name = "Notebook", Price = 100000 },
        new Product() { Id = 2, Name = "Car", Price = 2000000 },
        new Product() { Id = 3, Name = "Apple", Price = 30 },
});
        
        [HttpGet]
        public IEnumerable<Product> Get() => products;


        [HttpGet("{id}")]           // параметр для маршрутизации
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
