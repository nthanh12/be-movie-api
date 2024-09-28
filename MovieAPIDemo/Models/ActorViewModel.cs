using MovieAPIDemo.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieAPIDemo.Models
{
    public class ActorViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
