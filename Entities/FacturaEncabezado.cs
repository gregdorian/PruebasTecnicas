using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FacturaEncabezado
    {
        public FacturaEncabezado()
        {
           this.Lineas = new List<FacturaDetalle>();
        }
        public int IdEncabezado { get; set; }

        public int IdCliente { get; set; }

        public string NumeroFactura { get; set; }

        public string CodigoEmpresa { get; set; }

        public string CodigoCliente { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }


        public DateTime FechaFactura { get; set; }

        public List<FacturaDetalle> Lineas { get; set; }

        public decimal Sub_Total { get; set; }

    }
}
