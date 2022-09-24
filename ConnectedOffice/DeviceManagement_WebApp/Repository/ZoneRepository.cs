using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.IRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(
            ConnectedOfficeContext context,
            ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Zone>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll method Error", typeof(ZoneRepository));
                return new List<Zone>();
            }
        }


        public override async Task<bool> Upsert(Zone entity)
        {
            
            try
            {
                var existingZone = await dbSet.Where(x => x.ZoneId == entity.ZoneId).FirstOrDefaultAsync();

                if (existingZone == null)
                    return await Add(entity);

                existingZone.ZoneDescription = entity.ZoneDescription;
                existingZone.ZoneName = entity.ZoneName;
                existingZone.DateCreated = entity.DateCreated;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method Error", typeof(ZoneRepository));
                return false;
            }
        }


        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingZone = await dbSet.Where(x => x.ZoneId == id).FirstOrDefaultAsync();

                if (existingZone!=null)
                {
                    dbSet.Remove(existingZone);
                    return true;
                }

                return false;
                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method Error", typeof(ZoneRepository));
                return false;
            }
        }


        /*

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(zone => zone.DateCreated).FirstOrDefault();
        }

        public Zone GetZone()
        {
            return _context.Zone.ToList().FirstOrDefault();
        }*/

    }


}
