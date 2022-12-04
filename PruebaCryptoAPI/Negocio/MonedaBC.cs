using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MonedaBC
    {
        public Moneda? ObtenerMoneda(crypto_dbContext db,int id)
        {
            return db.Monedas.Include(a => a.Cuenta).FirstOrDefault(a => a.IdMoneda == id);
        }
    }
}
