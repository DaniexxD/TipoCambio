using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITipoCambio
{
    public class TipoCambio
    {
        public int Id { get; set; }

        public string MonedaOrigen { get; set; }

        public string MonedaDestino { get; set; }

        public double Valor { get; set; }

    }

}
