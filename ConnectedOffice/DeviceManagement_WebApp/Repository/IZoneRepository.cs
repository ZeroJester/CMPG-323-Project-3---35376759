//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repositories
{
    public interface IZoneRepository : IGenericRepository<Zone>
    {
        Zone GetMostRecentZone();
    }
}
