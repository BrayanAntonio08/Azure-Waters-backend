
using AW.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.AccesoDatos
{
    public class UsuarioDatos
    {
        public SqlConnection conn;

        public UsuarioDatos()
        {
            conn = new SqlConnection(ConexionDatos.CONECTION_LAPTOP); 
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand cmd = new SqlCommand("SELECT UsuarioId, NombreUsuario, Contrasenna FROM Usuarios", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                    NombreUsuario = reader["NombreUsuario"].ToString(),
                    Contrasenna = reader["Contrasenna"].ToString()
                });
            }
            return usuarios;
        }
    }
}
