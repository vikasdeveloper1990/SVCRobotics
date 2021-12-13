using Newtonsoft.Json;
using SVCRobotics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SVCRobotics.Services
{
    public class RoboSelectorService : IRobotSelectorService
    {
        public async Task<NearestRobot> GetAppropriateRobot(LoadRequest loadRequest)
        {
            var robots = new List<Robot>();
            var nearestRobot = new NearestRobot();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://60c8ed887dafc90017ffbd56.mockapi.io/robots");

                if (response.IsSuccessStatusCode)
                {
                    robots = JsonConvert.DeserializeObject<List<Robot>>(await response.Content.ReadAsStringAsync());
                }

            }

            var robo = GetNearestRobot(robots, loadRequest);

            nearestRobot.RobotId = robo.RobotId;
            nearestRobot.BatteryLevel = robo.BatteryLevel;

            nearestRobot.DistanceToGoal = NearestDataPoint(robo, loadRequest);
            return nearestRobot;
        }


        private Robot GetNearestRobot(List<Robot> robots, LoadRequest loadRequest)
        {
            var closestPoints = robots.
                               OrderBy(robo => NearestDataPoint(robo, loadRequest)).
                               OrderByDescending(ro=>ro.BatteryLevel).FirstOrDefault();

            return closestPoints;
        }

        private double NearestDataPoint(Robot robo, LoadRequest load)
        {
            return Math.Sqrt(Math.Pow(load.XAxis - robo.X, 2) + Math.Pow(load.Yaxis - robo.Y, 2));
        }

    }
}
