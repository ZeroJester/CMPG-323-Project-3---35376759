//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
            public Object ReturnDevices()
            {
                var data = context.Device.Include(d => d.Zone).Include(d => d.Category);
                return data;
            }

            public SelectList ReturnZoneList()
            {
                var data = new SelectList(context.Zone, "ZoneId", "ZoneName");
                return data;

            }

            public SelectList ReturnCategoryList()
            {
                var data = new SelectList(context.Category, "CategoryId", "CategoryName");
                return data;
            }
        }
    }
}
