using System.ComponentModel.DataAnnotations;
using System;

namespace ConcertHub.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Address { get; set; }

        [Range(1, 100000)]
        public int Capacity { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public List<Concert> Concerts { get; set; } = new();
    }
}
