using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FacturaDetalle
    {

        public int IdFacturaDetalle { get; set; }

        public int IdFacturaEncabezado { get; set; }

        public int IdProducto { get; set; }

        public string CodigoProducto { get; set; }

        public string NombreProducto { get; set; }

        public decimal Descuento { get; set; }
        
        //**** para uso solo de la clase
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        //**** adicionada a la clase no a la tabla
        private decimal _SubTotal;
        //**** adicionada a la clase no a la tabla
        public decimal Subtotal
        {
            get
            { return (Precio * Cantidad) * (1 - Descuento/100); }
            set
            { _SubTotal = value; }
        }
    }
}
