using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Infrastructure.Data;
using Entities;

namespace Domain.core
{
    public class RegistrarProductos
    {
        //private readonly ProductoPersistence ProducPer;

        public RegistrarProductos(/*ProductoPersistence producPer*/)
        {
            //producPer = ProducPer;
        }

        public static DataTable ConsultarProductos()
        {
            DataTable dtConsultaProductos;

            ProductoPersistence ProducPer = new ProductoPersistence();

            dtConsultaProductos = ProducPer.GetAllProductos();

            //List<DataRow> lstProductos = dtConsultaProductos.AsEnumerable().ToList();

            return dtConsultaProductos;
        }

        public void CreateFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence ProducPer = new ProductoPersistence();
                ProducPer.CreateProducto(oProducto);
            }
            catch (Exception ex)
            {
                //colocar mensaje de error si no cumple validaciones
                throw new Exception(ex.Message);
            }

        }

        public void UpdateFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence ProducPer = new ProductoPersistence();
                ProducPer.UpdateProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence ProducPer = new ProductoPersistence();
                ProducPer.DeleteProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
