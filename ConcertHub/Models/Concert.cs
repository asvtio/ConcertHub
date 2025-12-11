using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace ConcertHub.Models
{
    public class Concert
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int ArtistId { get; set; }
        public int VenueId { get; set; }

        [Range(0, 100000)]
        public decimal BaseTicketPrice { get; set; }

        public Artist? Artist { get; set; }
        public Venue? Venue { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
