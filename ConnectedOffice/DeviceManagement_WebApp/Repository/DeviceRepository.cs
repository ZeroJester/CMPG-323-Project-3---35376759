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

        //Return a selected device with its correlated device ID and category ID//
        public Object ReturnDevices()
        {
            var data = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return data;
        }

        //Return a list of all zone IDs//
        public SelectList ReturnZoneList()
        {
            var data = new SelectList(_context.Zone, "ZoneId", "ZoneId");
            return data;

        }

        //Return a list of all category IDs
        public SelectList ReturnCategoryList()
        {
            var data = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return data;
        }

        //Return the selected device's category ID//
        public Category ReturnCatId(Guid id)
        {
            Category categoryId = _context.Category.Find(id);
            return categoryId;

        }

        //Return the selected device's zone ID//
        public Zone ReturnZoneId(Guid id)
        {
            Zone zoneId = _context.Zone.Find(id);
            return zoneId;
        }
    }
}
