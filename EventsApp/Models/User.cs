using System.Collections.Generic;

namespace EventsApp.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Events = new List<Event>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}