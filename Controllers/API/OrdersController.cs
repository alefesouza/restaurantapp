using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.SQLite;
using RestaurantApp.Models;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApp.Controllers.API
{
    [Route("api/clients/{clientId}/[controller]")]
    public class OrdersController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get(int clientId)
        {
            using (var db = new RestaurantContext())
            {
                Client client = db.Client.FirstOrDefault(C => C.Id == clientId);

                List<Order> orders = new List<Order>(db.Order.Where(O => O.Client == client));

                if (orders != null)
                {
                    return Json(new Response() { Error = false, Result = orders });
                }
                else
                {
                    return Json(new Response() { Error = true, Description = "invalid_id" });
                }
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id, int clientId)
        {
            using (var db = new RestaurantContext())
            {
                Order order = db.Order.SingleOrDefault(O => O.Id == id);

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

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]Order value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    db.Order.Add(value);
                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success", Result = new { Id = value.Id } });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id, int clientId)
        {
            using (var db = new RestaurantContext())
            {
                Order order = db.Order.SingleOrDefault(C => C.Id == id);
                db.Order.Remove(order);
                db.SaveChanges();

                if (order != null)
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
