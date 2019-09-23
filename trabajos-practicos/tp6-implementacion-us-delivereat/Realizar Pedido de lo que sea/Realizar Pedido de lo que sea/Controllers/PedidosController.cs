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
    public class PedidosController : ApiController
    {
        private DeliverEatContext db = new DeliverEatContext();

        // GET: api/Pedidos
        public IQueryable<Pedido> GetPedidos()
        {
			return db.Pedidos
				.Include(p => p.DomicilioDestino)
				.Include(p => p.DomicilioOrigen)
				.Include(p => p.EstadoPedido)
				.Include(p => p.FormaPago)
				.Include(p => p.Tarjeta);
        }

        // GET: api/Pedidos/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(int id)
        {
            Pedido pedido = db.Pedidos.Include(p => p.DomicilioDestino)
				.Include(p => p.DomicilioOrigen)
				.Include(p => p.EstadoPedido)
				.Include(p => p.FormaPago)
				.Include(p => p.Tarjeta).Where<Pedido>(p => p.Id == id)
				.FirstOrDefault();
			if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // PUT: api/Pedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.Id)
            {
                return BadRequest();
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidos
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(pedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult DeletePedido(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedido);
            db.SaveChanges();

            return Ok(pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoExists(int id)
        {
            return db.Pedidos.Count(e => e.Id == id) > 0;
        }
    }
}