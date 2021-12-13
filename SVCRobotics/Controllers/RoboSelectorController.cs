using Microsoft.AspNetCore.Mvc;
using SVCRobotics.Models;
using SVCRobotics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVCRobotics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoboSelectorController : Controller
    {

        private IRobotSelectorService _roboSelectorService;
        public RoboSelectorController(IRobotSelectorService roboSelectorService)
        {
            _roboSelectorService = roboSelectorService;
        }


        [HttpPost]
        public async Task<NearestRobot> RobotForLoad([FromBody] LoadRequest loadRequest)
        {
            var res = await _roboSelectorService.GetAppropriateRobot(loadRequest);
            return res;
        }
    }
}
