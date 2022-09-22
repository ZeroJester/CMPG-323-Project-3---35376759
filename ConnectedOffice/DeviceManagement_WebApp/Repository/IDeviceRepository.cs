//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;


namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IDeviceRepository<Device>
    {
        Device GetAll();
    }
}
