using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsAddController : ApiController
    {
		List<Product> products = new List<Product>
		{
			new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
			new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3 },
			new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 1 }
		};

		// GET: api/ProductsAdd
		public IEnumerable<Product> GetProducts()
        {
			return products;
		}

		// GET: api/ProductsAdd/5
		[ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
			var product = products.FirstOrDefault((p) => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		// POST: api/ProductsAdd
		[ResponseType(typeof(Product))]
		public IHttpActionResult PostProduct(Product product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			this.products.Add(product);
			return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
		}

		//// PUT: api/ProductsAdd/5
		//[ResponseType(typeof(void))]
		//      public IHttpActionResult PutProduct(int id, Product product)
		//      {
		//          if (!ModelState.IsValid)
		//          {
		//              return BadRequest(ModelState);
		//          }

		//          if (id != product.Id)
		//          {
		//              return BadRequest();
		//          }

		//          db.Entry(product).State = EntityState.Modified;

		//          try
		//          {
		//              db.SaveChanges();
		//          }
		//          catch (DbUpdateConcurrencyException)
		//          {
		//              if (!ProductExists(id))
		//              {
		//                  return NotFound();
		//              }
		//              else
		//              {
		//                  throw;
		//              }
		//          }

		//          return StatusCode(HttpStatusCode.NoContent);
		//      }


		//// DELETE: api/ProductsAdd/5
		//[ResponseType(typeof(Product))]
		//public IHttpActionResult DeleteProduct(int id)
		//{
		//    Product product = db.Products.Find(id);
		//    if (product == null)
		//    {
		//        return NotFound();
		//    }

		//    db.Products.Remove(product);
		//    db.SaveChanges();

		//    return Ok(product);
		//}

		//protected override void Dispose(bool disposing)
		//{
		//    if (disposing)
		//    {
		//        db.Dispose();
		//    }
		//    base.Dispose(disposing);
		//}

		//private bool ProductExists(int id)
		//{
		//    return db.Products.Count(e => e.Id == id) > 0;
		//}
	}
}