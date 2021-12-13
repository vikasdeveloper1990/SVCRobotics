namespace SVCRobotics.Services
{
    using SVCRobotics.Models;
    using System.Threading.Tasks;

    public interface IRobotSelectorService
    {
        Task<NearestRobot> GetAppropriateRobot(LoadRequest loadRequest);
    }
}
