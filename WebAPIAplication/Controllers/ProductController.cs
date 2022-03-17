using Microsoft.AspNetCore.Mvc;
using WebAPIAplication.Models;

namespace WebAPIAplication.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product>Get(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.Id = Products.Count() + 1;
            Products.Add(model);
            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        [HttpPut("{productId}")]
        public ActionResult Update(int productId, Product model)
        {
            var originalEntry = Products.Single(x => x.Id == productId);
            originalEntry.Name = model.Name;
            originalEntry.Description = model.Description;
            originalEntry.Price = model.Price;

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult Update(int productId)
        {
            Products = Products.Where(x => x.Id != productId).ToList();
            return NoContent();
        }

        private static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Guitarra electrica",
                Description = "Utilizada para Riffs",
                Price = 5000
            },
            new Product
            {
                Id = 2,
                Name = "Guitarra acustica",
                Description = "Utilizada para musica clasica",
                Price = 300
            }
        };

    }
}
