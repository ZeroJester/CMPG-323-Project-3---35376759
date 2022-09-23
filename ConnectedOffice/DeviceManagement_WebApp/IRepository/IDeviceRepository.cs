using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.IRepository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Device GetMostRecentDevice();
    }
}
