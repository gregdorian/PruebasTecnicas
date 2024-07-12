using System;

namespace Domain.Entities
{
    /// <summary>
    /// Representa un producto en el sistema.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Obtiene o establece el identificador único del producto.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Obtiene o establece el código del producto.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Obtiene o establece el precio de venta del producto.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Obtiene o establece el precio de costo del producto.
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// Obtiene o establece el stock del producto.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Obtiene o establece el stock mínimo del producto.
        /// </summary>
        public int MinimalStock { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de ingreso del producto.
        /// </summary>
        public DateTime DateIngreso { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Product"/>.
        /// </summary>
        public Product()
        {
            // Inicialización de valores predeterminados si es necesario
            DateIngreso = DateTime.Now;
        }

        /// <summary>
        /// Valida los datos del producto.
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(CodigoProduct))
                throw new ArgumentException("El código del producto no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(NombreProduct))
                throw new ArgumentException("El nombre del producto no puede estar vacío.");

            if (UnitPrice < 0)
                throw new ArgumentException("El precio de venta no puede ser negativo.");

            if (CostPrice < 0)
                throw new ArgumentException("El precio de costo no puede ser negativo.");

            if (Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            if (MinimalStock < 0)
                throw new ArgumentException("El stock mínimo no puede ser negativo.");

            if (DateIngreso > DateTime.Now)
                throw new ArgumentException("La fecha de ingreso no puede ser en el futuro.");
        }
    }
}