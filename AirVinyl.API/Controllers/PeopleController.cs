using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AirVinyl.DataAccessLayer;
using AirVinyl.Model;
using Microsoft.AspNet.OData;

namespace AirVinyl.API.Controllers
{

    public class PeopleController : ODataController
    {
        private readonly AirVinylDbContext _context = new AirVinylDbContext();

        [EnableQuery]
        public IQueryable<Person> Get() => _context.People;

        [EnableQuery]
        public SingleResult<Person> Get([FromODataUri] int key)
        {
            var result = _context.People.Where(p => p.PersonId == key);
            return SingleResult.Create(result);
        }

        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.People.Add(person);
            return Created(person);

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}