//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;
using System.ComponentModel;
using System;
using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Device GetMostRecentService()
        {
            return _context.Device.OrderByDescending(service => service.CreatedDate).FirstOrDefault();
        }

    }
}
