using System;
using System.Collections.Generic;

namespace EventsApp.Models
{
    public class Event: BaseEntity
    {
        public Event()
        {
            Users = new List<User>();
        }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}