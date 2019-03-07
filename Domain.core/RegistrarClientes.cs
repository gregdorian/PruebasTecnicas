
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Entities;
using Infrastructure.Data;
namespace Domain.core
{
    public static class RegistrarClientes
    {
        

        public static DataTable ConsultarClientes()
        {
            DataTable dtConsultaProductos;
            ClientesPersistence ClientePer = new ClientesPersistence();
            dtConsultaProductos = ClientePer.GetAllClientes();

            return dtConsultaProductos;
        }

        public static void CreateClientes(Clientes oCliente)
        {
            try
            {
                ClientesPersistence ClientePer = new ClientesPersistence();
                ClientePer.CreateCliente(oCliente);
            }
            catch (Exception ex)
            {
                //colocar mensaje de error si no cumple validaciones
                throw new Exception(ex.Message);
            }

        }

        public static void UpdateClientes(Clientes oCliente)
        {
            try
            {
                ClientesPersistence ClientePer = new ClientesPersistence();
                ClientePer.UpdateCliente(oCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteClientes(Clientes oCliente)
        {
            try
            {
                ClientesPersistence ClientePer = new ClientesPersistence();
                ClientePer.DeleteCliente(oCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool GuardarCliente(Clientes oCliente)
        {
            return true;
        }
    }
}
