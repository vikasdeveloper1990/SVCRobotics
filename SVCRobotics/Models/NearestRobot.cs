using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVCRobotics.Models
{
    public class NearestRobot
    {
        public string RobotId { get; set; }
        public double DistanceToGoal { get; set; }
        public double BatteryLevel { get; set; }
    }
}
