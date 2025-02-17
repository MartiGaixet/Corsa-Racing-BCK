using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace CorsaRacing.Models
{
    public class Race
    {
        public int Id { get; set; }
        public List<User> Drivers { get; set; }
        public String Circuit { get; set; }
        public String Car { get; set; }
        public DateTime Date { get; set; }

        public List<ParticipationRace> ParticipationRace { get; set; }

        public int? ChampionshipId { get; set; }

        [JsonIgnore]
        public Championship? Championship { get; set; }

    }
}
