using System.ComponentModel.DataAnnotations;

namespace ConcertHub.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public List<Ticket> Tickets { get; set; } = new();

    }
}
