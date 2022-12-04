﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Operacion
    {
        public int IdOperacion { get; set; }
        public int IdTipoOperacion { get; set; }
        public int IdCuentaOrigen { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cotizacion { get; set; }
        public decimal Haber { get; set; }
        public decimal Debe { get; set; }
        public int IdCuentaDestino { get; set; }

        public virtual Cuenta IdCuentaDestinoNavigation { get; set; } = null!;
        public virtual Cuenta IdCuentaOrigenNavigation { get; set; } = null!;
        public virtual TipoOperacion IdTipoOperacionNavigation { get; set; } = null!;
    }
}
