using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace Infrastructure.Data
{
    public class ClientesPersistence
    {
        public DataTable GetAllClientes()
        {

            if (Conexion.EjecutarConsulta("GetAllClientes", CommandType.StoredProcedure).Rows.Count > 0)
            {
                return Conexion.EjecutarConsulta("GetAllClientes", CommandType.StoredProcedure);
            }
            else
            {
                return null;
            }
        }

        public DataTable GetIdCliente(int idCliente)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdCliente", idCliente);
            lista.Add(codigo);
            return Conexion.EjecutarConsulta("GetIdClientes", lista, CommandType.StoredProcedure);

        }

        public void CreateCliente(Clientes oClientes)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

           
            SqlParameter codigo = new SqlParameter("@P_CodigoCliente", oClientes.CodigoCliente);
            SqlParameter nombre = new SqlParameter("@P_NombreCliente", oClientes.NombreCliente);
            SqlParameter direc = new SqlParameter("@P_DireccionCliente", oClientes.DireccionCliente);
            SqlParameter telefono = new SqlParameter("@P_TelefonoCliente", oClientes.TelefonoCliente);
            SqlParameter descripcion = new SqlParameter("@P_DescripcionCliente", oClientes.DescripcionCliente);
            SqlParameter fechaIng = new SqlParameter("@P_FechaIngreso", oClientes.FechaIngreso);

            listaInsertar.Add(codigo);
            listaInsertar.Add(nombre);
            listaInsertar.Add(direc);
            listaInsertar.Add(telefono);
            listaInsertar.Add(descripcion);
            listaInsertar.Add(fechaIng);

            Conexion.EjecutarOperacion("ClientesInsert", listaInsertar, CommandType.StoredProcedure);

        }

        public void UpdateCliente(Clientes oCliente)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();


            SqlParameter codigo = new SqlParameter("@P_CodigoCliente", oCliente.CodigoCliente);
            SqlParameter nombre = new SqlParameter("@P_NombreCliente", oCliente.NombreCliente);
            SqlParameter direc = new SqlParameter("@P_DireccionCliente", oCliente.DireccionCliente);
            SqlParameter telefono = new SqlParameter("@P_TelefonoCliente", oCliente.TelefonoCliente);
            SqlParameter descripcion = new SqlParameter("@P_DescripcionCliente", oCliente.DescripcionCliente);
            SqlParameter fechaIng = new SqlParameter("@P_FechaIngreso", oCliente.FechaIngreso);

            listaInsertar.Add(codigo);
            listaInsertar.Add(nombre);
            listaInsertar.Add(direc);
            listaInsertar.Add(telefono);
            listaInsertar.Add(descripcion);
            listaInsertar.Add(fechaIng);

            Conexion.EjecutarOperacion("ClientesUpdate", listaInsertar, CommandType.StoredProcedure);
        }

        public void DeleteCliente(Clientes oCliente)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdCliente", oCliente.IdCliente);

            lista.Add(codigo);

            Conexion.EjecutarOperacion("ClientesDelete", lista, CommandType.StoredProcedure);
        }
    }
}
