using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.IRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }
    }
}
