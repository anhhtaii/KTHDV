using bth3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Danh sách sản phẩm giả lập (có thể thay thế bằng cơ sở dữ liệu)
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Sản phẩm A",
                Description = "Mô tả sản phẩm A",
                Price = 100000,
                Quantity = 10,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Product
            {
                Id = 2,
                Name = "Sản phẩm B",
                Description = "Mô tả sản phẩm B",
                Price = 200000,
                Quantity = 5,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product newProduct)
        {
            newProduct.Id = products.Max(p => p.Id) + 1;  // Tạo ID mới cho sản phẩm
            newProduct.CreatedAt = DateTime.Now;
            newProduct.UpdatedAt = DateTime.Now;
            products.Add(newProduct);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            // Cập nhật thông tin sản phẩm
            existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
            existingProduct.Description = updatedProduct.Description ?? existingProduct.Description;
            existingProduct.Price = updatedProduct.Price != 0 ? updatedProduct.Price : existingProduct.Price;
            existingProduct.Quantity = updatedProduct.Quantity != 0 ? updatedProduct.Quantity : existingProduct.Quantity;
            existingProduct.UpdatedAt = DateTime.Now;

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            products.Remove(product);
            return NoContent();
        }
    }
}
