using DeviceManagement_WebApp.IRepository;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Configuration
{
    public class IUnitOfWork
    {
        IZoneRepository Zone {get;}

        //public virtual Task CompleteAsync();
    }
}
