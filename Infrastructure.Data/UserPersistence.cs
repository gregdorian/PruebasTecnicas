using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class UserPersistence
    {
        public static DataTable GetAllUsuarios()
        {

            if (Conexion.EjecutarConsulta("GetAllUsuario", CommandType.StoredProcedure).Rows.Count > 0)
            {
                return Conexion.EjecutarConsulta("GetAllUsuario", CommandType.StoredProcedure);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetIdUsuario(int idUsuario)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdUsuario", idUsuario);
            lista.Add(codigo);
            return Conexion.EjecutarConsulta("UsuarioSelectID", lista, CommandType.StoredProcedure);

        }

        public static void CreateUsuario(Usuario oUsuario)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

            SqlParameter nombre = new SqlParameter("@P_NombreUsuario", oUsuario.NombreUsuario);
            SqlParameter claveUser = new SqlParameter("@P_DireccionUsuario", oUsuario.Clave);
            SqlParameter logUser = new SqlParameter("@P_TelefonoUsuario", oUsuario.LogIngresos);


            listaInsertar.Add(nombre);
            listaInsertar.Add(claveUser);
            listaInsertar.Add(logUser);

            Conexion.EjecutarOperacion("UsuarioInsert", listaInsertar, CommandType.StoredProcedure);

        }

        public static void UpdateUsuario(Usuario oUsuario)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

            SqlParameter nombre = new SqlParameter("@P_NombreUsuario", oUsuario.NombreUsuario);
            SqlParameter claveUser = new SqlParameter("@P_DireccionUsuario", oUsuario.Clave);
            SqlParameter logUser = new SqlParameter("@P_TelefonoUsuario", oUsuario.LogIngresos);


            listaInsertar.Add(nombre);
            listaInsertar.Add(claveUser);
            listaInsertar.Add(logUser);

            Conexion.EjecutarOperacion("UsuarioUpdate", listaInsertar, CommandType.StoredProcedure);
        }

        public static void DeleteUsuario(Usuario oUsuario)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdUsuario", oUsuario.UserId);

            lista.Add(codigo);

            Conexion.EjecutarOperacion("UsuarioDelete", lista, CommandType.StoredProcedure);
        }


    }
}
