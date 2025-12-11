using System.ComponentModel.DataAnnotations;
using System;

namespace ConcertHub.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Genre { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Country { get; set; }

        public List<Concert> Concerts { get; set; } = new();
    }
}
