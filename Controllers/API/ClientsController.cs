using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.SQLite;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        // GET: api/clients
        [HttpGet]
        public JsonResult Get()
        {
            using (var db = new RestaurantContext())
            {
                List<Client> clients = new List<Client>(db.Client);

                if (clients != null)
                {
                    return Json(new Response() { Error = false, Result = clients });
                }
                else
                {
                    return Json(new Response() { Error = true, Description = "invalid_id" });
                }
            }
        }

        // GET api/clients/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            using (var db = new RestaurantContext())
            {
                Client order = db.Client.First(O => O.Id == id);

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

        // POST api/clients
        [HttpPost]
        public JsonResult Post([FromBody]Client value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    db.Client.Add(value);
                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success", Result = new { Id = value.Id } });
                }
            }
            catch(Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // PUT api/clients/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Client value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    Client client = db.Client.SingleOrDefault(O => O.Id == id);

                    value.Id = client.Id;

                    db.Entry(client).CurrentValues.SetValues(value);

                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success" });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }

        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            using (var db = new RestaurantContext())
            {
                Client order = db.Client.First(O => O.Id == id);
                db.Client.Remove(order);
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
