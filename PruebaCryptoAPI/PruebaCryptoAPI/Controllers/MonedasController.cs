using Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Reflection.Metadata.Ecma335;

namespace PruebaCryptoAPI.Controllers
{
    [Route("api/monedas")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        [HttpGet("all")]
        public List<Moneda> Get()
        {
            using (var db = new crypto_dbContext())
            {
                //return db.Monedas.ToList();
                return db.Monedas.Include(a => a.Cuenta).ToList();
            }
        }

        [HttpGet("{id}")]
        public Moneda? Get(int id)
        {
            using(var db = new crypto_dbContext())
            {
                return new MonedaBC().ObtenerMoneda(db, id);
            }
        }

        [HttpPost]
        public void Post([FromBody] Moneda miMoneda)
        {
            using (var db = new crypto_dbContext())
            {
                db.Monedas.Add(miMoneda);
                db.SaveChanges(); // manda cambios a la bbdd
            }
        }

        [HttpPut]
        public void Put([FromBody] Moneda miMoneda)
        {
            using(var db=new crypto_dbContext())
            {
                Moneda? monedaVieja = db.Monedas.FirstOrDefault(a=>a.IdMoneda==miMoneda.IdMoneda);
                monedaVieja.Codigo = miMoneda.Codigo;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                using (var db = new crypto_dbContext())
                {
                    Moneda? miMoneda = db.Monedas.FirstOrDefault(a => a.IdMoneda == id);
                    db.Remove(miMoneda);
                    db.SaveChanges(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
