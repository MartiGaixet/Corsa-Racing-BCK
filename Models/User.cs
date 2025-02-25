using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace CorsaRacing.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email  { get; set; }
        public String Password { get; set; }
        public String Country { get; set; }
        public float Rating { get; set; }


        [JsonIgnore]
        public List<ParticipationRace>? ParticipationRaces { get; set; }


    }
}
