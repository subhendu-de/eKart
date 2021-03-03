using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public void Post([FromBody]Product value)
        {
            _context.Products.Add(value);
            _context.SaveChanges();
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product value)
        {
            var _product = _context.Products.FirstOrDefault(x => x.ID == value.ID);
            _product.Name = value.Name;
            _context.SaveChanges();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _product = _context.Products.FirstOrDefault(x => x.ID == id);
            _context.Products.Remove(_product);
            _context.SaveChanges();
        }
    }
}