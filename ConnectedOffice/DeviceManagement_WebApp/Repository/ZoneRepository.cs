//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using DeviceManagement_WebApp.Models;
using System.Linq;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Repositories
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(zone => zone.DateCreated).FirstOrDefault();
        }

    }
}
