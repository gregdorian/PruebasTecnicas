using System;
using System.Collections.Generic;
using System.Data;

using Entities;
using Domain.core;


namespace Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "VentaService" en el código y en el archivo de configuración a la vez.
    public class VentaService : IVentaService
    {
        public RegistrarClientes regCliente;
        public RegistrarProductos regProd;

        public VentaService()
        {
        }

        public VentaService(RegistrarClientes RegCliente, RegistrarProductos RegProd)
        {
            RegCliente = regCliente;
            RegProd = regProd;
        }

        public static List<DataRow> GetClientes()
        {
            return regCliente.ConsultarClientes();
        }

        public List<DataRow> GetProductos()
        {
            return regProd.ConsultarProductos(); /// buscar el id
        }

        public bool GuardarComprobante(Venta vta)
        {
            return true;
        }
    }
}
