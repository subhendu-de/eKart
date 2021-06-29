using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eKart.Api.Data;

namespace eKart.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly eKartContext _context;

        public ProductsController(eKartContext context)
        {
            _context = context;
        }
        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ID == id);
        }

        // POST api/products
        [HttpPost]
        public async Task<int> Post([FromBody]Product value)
        {
            _context.Products.Add(value);
            return await _context.SaveChangesAsync();
        }
        
        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody]Product value)
        {
            var _product = _context.Products.FirstOrDefault(x => x.ID == value.ID);
            _product.Name = value.Name;
            return await _context.SaveChangesAsync();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            var _product = _context.Products.FirstOrDefault(x => x.ID == id);
            _context.Products.Remove(_product);
            return await _context.SaveChangesAsync();
        }
    }
}