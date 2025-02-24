namespace CorsaRacing.Models
{
    public class ParticipationRace
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RaceId { get; set; }

        // Relaciones Many-to-Many
        public User? Driver { get; set; }
        public Race? Race { get; set; }
    }
}
