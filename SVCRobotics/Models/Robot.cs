using System.Text.Json.Serialization;

namespace SVCRobotics.Models
{
    public class Robot
    {
        [JsonPropertyName("robotId")]
        public string RobotId { get; set; }

        [JsonPropertyName("batteryLevel")]
        public int BatteryLevel { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }
    }
}