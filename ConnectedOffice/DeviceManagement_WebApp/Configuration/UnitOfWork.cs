using System;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Configuration;
using DeviceManagement_WebApp.Controllers;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.IRepository;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace DeviceManagement_WebApp.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ConnectedOfficeContext _context;
        private readonly ILogger _logger;

        public IZoneRepository Zone { get; private set; }


        public UnitOfWork(
            ConnectedOfficeContext context,
            ILoggerFactory loggerNew)
        {
            _context = context;
            _logger = loggerNew.CreateLogger("logs");

            Zone = new ZoneRepository(_context, _logger);
        }

  

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
