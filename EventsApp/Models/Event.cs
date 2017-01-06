using System;
using System.Collections.Generic;

namespace EventsApp.Models
{
    public class Event: BaseEntity
    {
        public Event()
        {
            Users = new List<User>();
            Sessions = new List<Session>();
            Time = DateTime.Now;
        }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public ICollection<Session> Sessions { get; set; }


    }
}