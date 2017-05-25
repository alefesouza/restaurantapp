using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.SQLite;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET: api/products
        [HttpGet]
        public JsonResult Get()
        {
            using (var db = new RestaurantContext())
            {
                List<Product> products = new List<Product>(db.Product);

                if (products != null)
                {
                    return Json(new Response() { Error = false, Result = products });
                }
                else
                {
                    return Json(new Response() { Error = true, Description = "invalid_id" });
                }
            }
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            using (var db = new RestaurantContext())
            {
                Product product = db.Product.First(C => C.Id == id);

                if (product != null)
                {
                    return Json(new Response() { Error = false, Result = product });
                }
                else
                {
                    return Json(new Response() { Error = true, Description = "invalid_id" });
                }
            }
        }

        // POST api/products
        [HttpPost]
        public JsonResult Post([FromBody]Product value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    db.Product.Add(value);
                    db.SaveChanges();

                    Product product = db.Product.SingleOrDefault(P => P.Id == value.Id);

                    return Json(new Response { Error = false, Description = "success", Result = new { Id = value.Id } });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Product value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    Product product = db.Product.First(P => P.Id == id);

                    value.Id = product.Id;

                    db.Entry(product).CurrentValues.SetValues(value);

                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success" });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            using (var db = new RestaurantContext())
            {
                Product product = db.Product.First(C => C.Id == id);
                db.Product.Remove(product);
                db.SaveChanges();

                if (product != null)
                {
                    return Json(new Response() { Error = false, Description = "success" });
                }
                else
                {
                    return Json(new Response() { Error = true, Description = "invalid_id" });
                }
            }
        }
    }
}