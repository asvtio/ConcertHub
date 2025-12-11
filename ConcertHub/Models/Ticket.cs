namespace ConcertHub.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int ConcertId { get; set; }
        public int? UserId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsPurchased { get; set; } = false;
        public DateTime? PurchaseDate { get; set; }

        public Concert? Concert { get; set; }
        public User? User { get; set; }
    }
}
