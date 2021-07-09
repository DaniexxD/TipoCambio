using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITipoCambio;
using APITipoCambio.Data;

namespace APITipoCambio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambiosController : ControllerBase
    {
        private readonly APITipoCambioContext _context;

        public TipoCambiosController(APITipoCambioContext context)
        {
            _context = context;

            if (_context.TipoCambio.Count() == 0)
            {
                List<TipoCambio> tc = new List<TipoCambio>();
                tc.Add(new TipoCambio { MonedaOrigen = "PEN", MonedaDestino = "USD", Valor = 3.96 });
                tc.Add(new TipoCambio { MonedaOrigen = "PEN", MonedaDestino = "EUR", Valor = 4.69 });
                tc.Add(new TipoCambio { MonedaOrigen = "USD", MonedaDestino = "EUR", Valor = 0.84 });
                tc.Add(new TipoCambio { MonedaOrigen = "USD", MonedaDestino = "PEN", Valor = 0.25 });
                _context.TipoCambio.AddRange(tc);
                _context.SaveChanges();
            }

        }

        // GET: api/TipoCambios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCambio>>> GetTipoCambio()
        {
            return await _context.TipoCambio.ToListAsync();
        }

        [HttpGet("{monto}/{monedaOrigen}/{monedaDestino}")]
        public async Task<double> GetCambiario(double monto, string monedaOrigen, string monedaDestino)
        {
            var tc = await _context.TipoCambio
                .Where(b => b.MonedaOrigen == monedaOrigen.ToUpper() && b.MonedaDestino == monedaDestino.ToUpper()).SingleOrDefaultAsync();
            if ( tc == null)
            {
                return 0;
            }
            var calculo = monto * tc.Valor;
            return calculo ;
        }


        // POST: api/TipoCambios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoCambio>> PostTipoCambio(TipoCambio tipoCambio)
        {
            _context.TipoCambio.Add(tipoCambio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCambio", new { id = tipoCambio.Id }, tipoCambio);
        }

    }
}

