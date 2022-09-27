//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        //Returns an object based on ZoneId and CategoryId//
        public Object ReturnDevices();


        //Populates the device inputbox with a list of Zone ID's//
        public SelectList ReturnZoneList();


        //Populates the device inputbox with a list of Category ID's//
        public SelectList ReturnCategoryList();
    }
}
