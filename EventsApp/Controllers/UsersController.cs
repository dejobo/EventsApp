using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventsApp.Models;

namespace EventsApp.Controllers
{
    public class UsersController : ApiController
    {
        private readonly AppDbContext _context;

        public UsersController()
        {
            _context = new AppDbContext();
        }

        public IHttpActionResult Get()
        {
            var users = _context.Users.Select(x => new
            {
                x.Id,
                x.Name,
                x.Email,
                x.Age,
                Events = x.Events.Select(e => new
                {
                    e.Id,
                    e.Title,
                    e.Time
                }).OrderByDescending(e=>e.Time)
            }).OrderBy(x=>x.Name);
            return Ok(users);
        }

        public IHttpActionResult Get(int id)
        {
            var user = _context.Users.Find(id);
            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Age,
                Events = user.Events.Select(e => new
                {
                    e.Id,
                    e.Title,
                    e.Time,
                    e.Location,
                }).OrderByDescending(e => e.Time)
            });
        }

        public IHttpActionResult Post([FromBody] User model)
        {
            _context.SetAdd(model);
            _context.SaveChanges();
            return Ok(model);
        }

        public IHttpActionResult Put([FromBody] User model, int id)
        {
           _context.SetModified(model);
            _context.SaveChanges();
            return Ok(model);
        }
        public IHttpActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}
