using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using EventsApp.Models;

namespace EventsApp.Controllers
{
    public class EventsController : ApiController
    {
        public readonly AppDbContext Context;
        public EventsController()
        {
            Context = new AppDbContext();
        }

        public IHttpActionResult Get()
        {
            var events = Context.Events.Select(x => new
            {
                x.Id,
                x.Title,
                x.Time,
                x.Location,
                Users = x.Users.Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Age,
                    u.Email
                }).OrderBy(u => u.Name)
            }).OrderByDescending(x => x.Time);
            return Ok(events);
        }

        public IHttpActionResult Get(int id)
        {
            var @event = Context.Events.Find(id);
            return Ok(new
            {
                @event.Id,
                @event.Title,
                @event.Time,
                @event.Location,
                Users = @event.Users.Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Age,
                    u.Email
                }).OrderBy(u => u.Name)
            });
        }

        [Route("api/events/{eventId}/users")]
        public IHttpActionResult GetEventUsers(int eventId)
        {
            var @event = Context.Events.Find(eventId);
            return Ok(new
            {
                @event.Title,
                @event.Time,
                @event.Location,
                Users = Context.Users.Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Age,
                    u.Email,
                    IsSelected = u.Events.Any(e => e.Id == eventId)
                }).OrderBy(u => u.Name)
            });
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] Event model)
        {
            var @event = new Event
            {
                Title = model.Title,
                Time = model.Time,
                Location = model.Location
            };
            var newEvent = Context.Events.Add(@event);

            foreach (var user in model.Users)
            {
                newEvent.Users.Add(Context.Users.Find(user.Id));
            }
            Context.SaveChanges();

            return Ok(@event);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Event model, int id)
        {
            var @event = Context.Events.Find(id);
            @event.Title = model.Title;
            @event.Time = model.Time;
            @event.Location = model.Location;

            //remove existing users
            @event.Users.Clear();

            foreach (var user in model.Users)
            {
                @event.Users.Add(Context.Users.Find(user.Id));
            }

            Context.SetModified(@event);
            Context.SaveChanges();

            return Ok(@event);
        }
    }
}
