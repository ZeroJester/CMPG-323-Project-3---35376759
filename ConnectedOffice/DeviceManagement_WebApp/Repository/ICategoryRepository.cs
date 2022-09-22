//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;


namespace DeviceManagement_WebApp.Repositories
{
    public interface ICategoryRepository : IDeviceRepository<Category>
    {
        Category GetAll();
    }
}