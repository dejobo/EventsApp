using System;
using System.ComponentModel.DataAnnotations;

namespace EventsApp.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        //Add Audit fields here
        public DateTime Created { get; set; }

        public BaseEntity()
        {
            Created = DateTime.Now;
        }
    }
}