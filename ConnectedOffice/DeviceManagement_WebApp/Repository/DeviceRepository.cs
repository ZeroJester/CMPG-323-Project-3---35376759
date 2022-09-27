//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        private readonly ConnectedOfficeContext _context;
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
            _context = context;
        }

        public Object ReturnDevices()
        {
            var data = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return data;
        }

        public SelectList ReturnZoneList()
        {
            var data = new SelectList(_context.Zone, "ZoneId", "ZoneId");
            return data;

        }

        public SelectList ReturnCategoryList()
        {
            var data = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return data;
        }
    }
}
