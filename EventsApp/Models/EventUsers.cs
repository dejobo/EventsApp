using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApp.Models
{
    public class EventUsers: BaseEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}