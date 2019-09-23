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
    public class TarjetasController : ApiController
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: api/Tarjetas
        public IQueryable<Tarjeta> GetTarjetas()
        {
            return db.Tarjetas;
        }

        // GET: api/Tarjetas/5
        [ResponseType(typeof(Tarjeta))]
        public IHttpActionResult GetTarjeta(int id)
        {
            Tarjeta tarjeta = db.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return Ok(tarjeta);
        }

        // PUT: api/Tarjetas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarjeta(int id, Tarjeta tarjeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarjeta.Id)
            {
                return BadRequest();
            }

            db.Entry(tarjeta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaExists(id))
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

        // POST: api/Tarjetas
        [ResponseType(typeof(Tarjeta))]
        public IHttpActionResult PostTarjeta(Tarjeta tarjeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tarjetas.Add(tarjeta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarjeta.Id }, tarjeta);
        }

        // DELETE: api/Tarjetas/5
        [ResponseType(typeof(Tarjeta))]
        public IHttpActionResult DeleteTarjeta(int id)
        {
            Tarjeta tarjeta = db.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            db.Tarjetas.Remove(tarjeta);
            db.SaveChanges();

            return Ok(tarjeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarjetaExists(int id)
        {
            return db.Tarjetas.Count(e => e.Id == id) > 0;
        }
    }
}