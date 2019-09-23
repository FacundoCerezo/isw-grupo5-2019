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
    public class EstadosPedidoController : ApiController
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: api/EstadosPedido
        public IQueryable<EstadoPedido> GetEstadosPedido()
        {
            return db.EstadosPedido;
        }

        // GET: api/EstadosPedido/5
        [ResponseType(typeof(EstadoPedido))]
        public IHttpActionResult GetEstadoPedido(int id)
        {
            EstadoPedido estadoPedido = db.EstadosPedido.Find(id);
            if (estadoPedido == null)
            {
                return NotFound();
            }

            return Ok(estadoPedido);
        }

        // PUT: api/EstadosPedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadoPedido(int id, EstadoPedido estadoPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoPedido.Id)
            {
                return BadRequest();
            }

            db.Entry(estadoPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPedidoExists(id))
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

        // POST: api/EstadosPedido
        [ResponseType(typeof(EstadoPedido))]
        public IHttpActionResult PostEstadoPedido(EstadoPedido estadoPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadosPedido.Add(estadoPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadoPedido.Id }, estadoPedido);
        }

        // DELETE: api/EstadosPedido/5
        [ResponseType(typeof(EstadoPedido))]
        public IHttpActionResult DeleteEstadoPedido(int id)
        {
            EstadoPedido estadoPedido = db.EstadosPedido.Find(id);
            if (estadoPedido == null)
            {
                return NotFound();
            }

            db.EstadosPedido.Remove(estadoPedido);
            db.SaveChanges();

            return Ok(estadoPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoPedidoExists(int id)
        {
            return db.EstadosPedido.Count(e => e.Id == id) > 0;
        }
    }
}