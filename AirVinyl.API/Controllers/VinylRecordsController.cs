using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AirVinyl.DataAccessLayer;
using AirVinyl.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;

namespace AirVinyl.API.Controllers
{
    public class VinylRecordsController : ODataController
    {
        private readonly AirVinylDbContext _context = new AirVinylDbContext();

        [HttpGet]
        [EnableQuery]
        [ODataRoute("VinylRecords")]
        public IQueryable<VinylRecord> GetVinylRecords() => _context.VinylRecords;

        [HttpGet]
        [EnableQuery]
        [ODataRoute("VinylRecords({id})")]
        public SingleResult<VinylRecord> Get([FromODataUri] int id)
        {
            var result = _context.VinylRecords.Where(p => p.VinylRecordId == id);
            return SingleResult.Create(result);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}