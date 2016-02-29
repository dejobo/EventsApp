using System.ComponentModel.DataAnnotations;

namespace EventsApp.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        //Add Audit fields here
    }
}