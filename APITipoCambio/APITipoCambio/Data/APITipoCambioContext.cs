using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APITipoCambio;

namespace APITipoCambio.Data
{
    public class APITipoCambioContext : DbContext
    {
        public APITipoCambioContext (DbContextOptions<APITipoCambioContext> options)
            : base(options)
        {
        }

        public DbSet<APITipoCambio.TipoCambio> TipoCambio { get; set; }

    }

    public class TipoCambio
    {
        public int Id { get; set; }
        public string MonedaOrigen { get; set; }

        public string MonedaDestino { get; set; }

        public double Valor { get; set; }
    }
}
