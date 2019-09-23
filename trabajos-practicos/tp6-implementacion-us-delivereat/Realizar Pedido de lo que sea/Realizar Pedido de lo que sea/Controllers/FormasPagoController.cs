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
    public class FormasPagoController : ApiController
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: api/FormasPago
        public IQueryable<FormaPago> GetFormasPago()
        {
            return db.FormasPago;
        }

        // GET: api/FormasPago/5
        [ResponseType(typeof(FormaPago))]
        public IHttpActionResult GetFormaPago(int id)
        {
            FormaPago formaPago = db.FormasPago.Find(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            return Ok(formaPago);
        }

        // PUT: api/FormasPago/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormaPago(int id, FormaPago formaPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formaPago.Id)
            {
                return BadRequest();
            }

            db.Entry(formaPago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormaPagoExists(id))
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

        // POST: api/FormasPago
        [ResponseType(typeof(FormaPago))]
        public IHttpActionResult PostFormaPago(FormaPago formaPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FormasPago.Add(formaPago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formaPago.Id }, formaPago);
        }

        // DELETE: api/FormasPago/5
        [ResponseType(typeof(FormaPago))]
        public IHttpActionResult DeleteFormaPago(int id)
        {
            FormaPago formaPago = db.FormasPago.Find(id);
            if (formaPago == null)
            {
                return NotFound();
            }

            db.FormasPago.Remove(formaPago);
            db.SaveChanges();

            return Ok(formaPago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormaPagoExists(int id)
        {
            return db.FormasPago.Count(e => e.Id == id) > 0;
        }
    }
}