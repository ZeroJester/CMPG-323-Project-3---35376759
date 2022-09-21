//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;
using static DeviceManagement_WebApp.Repositories.IGenericRepository;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetMostRecentDevice();
    }
}
