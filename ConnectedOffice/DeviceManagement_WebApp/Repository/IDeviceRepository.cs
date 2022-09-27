//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Repository
{
    //IDeviceRepository inherits from IGenericRepository//
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        //Returns an object based on ZoneId and CategoryId//
        public Object ReturnDevices();

        //Populates the device inputbox with a list of Zone ID's//
        public SelectList ReturnZoneList();

        //Populates the device inputbox with a list of Category ID's//
        public SelectList ReturnCategoryList();

        //Return the selected device's category ID//
        public Category ReturnCatId(Guid id);

        //Return the selected device's zone ID//
        public Zone ReturnZoneId(Guid id);    
    }
}
