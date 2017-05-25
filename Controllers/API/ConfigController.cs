using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.SQLite;
using RestaurantApp.Models;
using RestaurantApp.Other;

namespace RestaurantApp.Controllers.API
{
    [Route("api/config")]
    public class ConfigController : Controller
    {
        // GET: api/config
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    Restaurant config;

                    if(db.Restaurant.Count() > 0)
                    {
                        config = db.Restaurant.First();
                    }
                    else
                    {
                        config = new Restaurant { Name = "", Tables = 0, Logo = "" };
                    }

                    return Json(new Response() { Error = false, Result = config });
                }
            }
            catch(InvalidOperationException e)
            {
                return Json(new Response() { Error = true, Description = "not_exists" });
            }
        }

        // POST api/config
        [HttpPost]
        public JsonResult Post([FromBody]Restaurant value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    db.Add(value);

                    if(!string.IsNullOrEmpty(value.Logo))
                    {
                        Utils.SaveFileFromBase64(value.LogoBase64, value.Logo, "logo");
                    }

                    db.SaveChanges();

                    return Json(new Response { Error = false, Description = "success", Result = new { Id = value.Id } });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = e.Message });
            }
        }

        // PUT api/config/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Restaurant value)
        {
            try
            {
                using (var db = new RestaurantContext())
                {
                    Restaurant config = db.Restaurant.First();

                    value.Id = config.Id;

                    db.Entry(config).CurrentValues.SetValues(value);

                    if (!string.IsNullOrEmpty(value.Logo))
                    {
                        Utils.SaveFileFromBase64(value.LogoBase64, value.Logo, "logo");
                    }

                    return Json(new Response { Error = false, Description = "success" });
                }
            }
            catch (Exception e)
            {
                return Json(new Response { Error = true, Description = "error_occurred", Result = e });
            }
        }
    }
}
