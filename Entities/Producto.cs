using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string CodigoProducto { get; set; }

        public string NombreProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal PrecioCosto { get; set; }

        public int Stock { get; set; }

        public int StockMinimo { get; set; }

        public DateTime FechaIngreso { get; set; }


    }
}
