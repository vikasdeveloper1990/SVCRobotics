using System.Text.Json.Serialization;

namespace SVCRobotics.Models
{
    public class LoadRequest
    {
        [JsonPropertyName("loadId")]
        public int LoadId { get; set; }

        [JsonPropertyName("x")]
        public int XAxis { get; set; }

        [JsonPropertyName("y")]
        public int Yaxis { get; set; }
    }
}
