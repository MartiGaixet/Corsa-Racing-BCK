using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace CorsaRacing.Models
{
    public class ParticipationRace
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RaceId { get; set; }

        // Relaciones Many-to-Many
        [JsonIgnore]
        public User? Driver { get; set; }
        [JsonIgnore]
        public Race? Race { get; set; }
    }
}
