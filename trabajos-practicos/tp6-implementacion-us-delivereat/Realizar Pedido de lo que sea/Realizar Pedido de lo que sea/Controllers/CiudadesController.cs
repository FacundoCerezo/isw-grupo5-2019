using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DeliverEat.BackEnd.Model.CodeFirst;

namespace Realizar_Pedido_de_lo_que_sea.Controllers
{
    public class CiudadesController : ApiController
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: api/Ciudades
        public IQueryable<Ciudad> GetCiudades()
        {
            return db.Ciudades;
        }

        // GET: api/Ciudades/5
        [ResponseType(typeof(Ciudad))]
        public IHttpActionResult GetCiudad(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return Ok(ciudad);
        }

        // PUT: api/Ciudades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCiudad(int id, Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ciudad.Id)
            {
                return BadRequest();
            }

            db.Entry(ciudad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ciudades
        [ResponseType(typeof(Ciudad))]
        public IHttpActionResult PostCiudad(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudades.Add(ciudad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ciudad.Id }, ciudad);
        }

        // DELETE: api/Ciudades/5
        [ResponseType(typeof(Ciudad))]
        public IHttpActionResult DeleteCiudad(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            db.Ciudades.Remove(ciudad);
            db.SaveChanges();

            return Ok(ciudad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CiudadExists(int id)
        {
            return db.Ciudades.Count(e => e.Id == id) > 0;
        }
    }
}