using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Entities;
using Infrastructure.Data;

namespace Domain.core
{
    public static class Venta
    {

 
        public static List<DataRow> ConsultarFacturasId(int IdFacturaEncabezado)
        {
           
            DataTable dtConsultaFactura;
            dtConsultaFactura = FacturaPersistence.GetIdFactura(IdFacturaEncabezado);

            List<DataRow> lstClientes = dtConsultaFactura.AsEnumerable().ToList();

            return lstClientes;
        }

        public static List<DataRow> ConsultarFacturas()
        {

            DataTable dtConsultaFactura;
            dtConsultaFactura = FacturaPersistence.GetAllFacturas();

            List<DataRow> lstClientes = dtConsultaFactura.AsEnumerable().ToList();

            return lstClientes;
        }


        public static bool RegistrarFacturaVenta(FacturaEncabezado oFacturaVta)
        {
            try
            {
               
                FacturaPersistence.CreateFactura(oFacturaVta);
                return true;
            }
            catch (Exception ex )
            {
                return false;
                throw ex;
            }
            
        }



    }
}
