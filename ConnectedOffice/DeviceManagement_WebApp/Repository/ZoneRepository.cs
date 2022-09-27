//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;


namespace DeviceManagement_WebApp.Repository
{
    //ZoneRepository inherits from GenericRepository and IZoneRepository//
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) :base(context)
        {
        }
    }
}
