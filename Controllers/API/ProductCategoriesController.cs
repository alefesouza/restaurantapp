using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using RestaurantApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Controllers.API
{
    [Route("api/product-categories")]
    public class ProductCategoryController : Controller
    {
        // GET: api/product-categories
        [HttpGet]
        public JsonResult Get()
        {
            using (var db = new RestaurantContext())
            {
                List<ProductCategory> orders = new List<ProductCategory>(db.ProductCategory);

                return Json(new Response() { Error = false, Result = orders });
            }
        }

        // GET api/product-categories/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            using (var db = new RestaurantContext())
            {
                ProductCategory order = db.ProductCategory.First(P => P.Id == id);

                if (order != null)
                {
                    return Json(new Response() { Error = false, Result = order });
                }
                else
                {
                    return Json(new Response() { Error = true, Description = "invalid_id" });
                }
            }
        }

        // POST api/product-categories
        [HttpPost]
        public JsonResult Post([FromBody]ProductCategory value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    db.ProductCategory.Add(value);
                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success", Result = new { Id = value.Id } });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // PUT api/product-categories/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Product value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    ProductCategory productCategory = db.ProductCategory.First(P => P.Id == id);

                    value.Id = productCategory.Id;

                    db.Entry(productCategory).CurrentValues.SetValues(value);

                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success" });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // DELETE api/product-categories/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    ProductCategory productCategory = db.ProductCategory.First(P => P.Id == id);
                    db.ProductCategory.Remove(productCategory);
                    db.SaveChanges();

                    if (productCategory != null)
                    {
                        return Json(new Response() { Error = false, Description = "success" });
                    }
                    else
                    {
                        return Json(new Response() { Error = true, Description = "invalid_id" });
                    }
                }
            }
            catch
            {
                return Json(new Response() { Error = true, Description = "invalid_id" });
            }
        }
    }
}
