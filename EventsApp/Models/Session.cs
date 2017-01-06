using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApp.Models
{
    public class Session: BaseEntity
    {
        public string Title { get; set; }
        public string Time { get; set; }
        public string Speaker { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }


    }
}