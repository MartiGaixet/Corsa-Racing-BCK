namespace CorsaRacing.Models
{
    public class Championship
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public List<Race> Races { get; set; } = new List<Race>();
        
    }
}
