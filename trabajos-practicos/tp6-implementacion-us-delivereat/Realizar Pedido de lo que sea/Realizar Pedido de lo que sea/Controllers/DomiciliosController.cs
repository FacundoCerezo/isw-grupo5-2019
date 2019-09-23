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
    public class DomiciliosController : ApiController
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: api/Domicilios
        public IQueryable<Domicilio> GetDomicilios()
        {
            return db.Domicilios.Include(d => d.Ciudad);
        }

        // GET: api/Domicilios/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult GetDomicilio(int id)
        {
            Domicilio domicilio = db.Domicilios
				.Include(d => d.Ciudad)
				.Where<Domicilio>(d => d.Id == id)
				.FirstOrDefault();
            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio);
        }

        // PUT: api/Domicilios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDomicilio(int id, Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != domicilio.Id)
            {
                return BadRequest();
            }

            db.Entry(domicilio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomicilioExists(id))
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

        // POST: api/Domicilios
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult PostDomicilio(Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Domicilios.Add(domicilio);
			try
			{
				db.SaveChanges();
			}
			catch (Exception)
			{

				BadRequest(ModelState);
			}

            return CreatedAtRoute("DefaultApi", new { id = domicilio.Id }, domicilio);
        }

        // DELETE: api/Domicilios/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult DeleteDomicilio(int id)
        {
            Domicilio domicilio = db.Domicilios.Find(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            db.Domicilios.Remove(domicilio);
            db.SaveChanges();

            return Ok(domicilio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DomicilioExists(int id)
        {
            return db.Domicilios.Count(e => e.Id == id) > 0;
        }
    }
}