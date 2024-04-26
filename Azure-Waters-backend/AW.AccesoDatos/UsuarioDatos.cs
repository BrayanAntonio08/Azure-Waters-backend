
using AW.Entidades;
using Azure_Waters_backend.Models;
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
            conn = new SqlConnection(ConexionDatos.ACTIVE_CONECTION); //Cambiar la conexión a la base de datos respectiva para que funcione
        }

        public List<Usuario> GetUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand cmd = new SqlCommand("SELECT id, nombre_usuario, contrasenna FROM Usuario", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    NombreUsuario = reader["nombre_usuario"].ToString(),
                    Contrasenna = reader["contrasenna"].ToString()
                });
            }
            return usuarios;
        }

        public Usuario BuscarUsuario(string usuario, string contrasenna)
        {
            Usuario usuarioEncontrado = null;

            SqlCommand cmd = new SqlCommand("SELECT id, nombre_usuario, contrasenna FROM Usuario WHERE nombre_usuario = @Usuario AND contrasenna = @Contrasenna", conn);
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Contrasenna", contrasenna);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                usuarioEncontrado = new Usuario()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    NombreUsuario = reader["nombre_usuario"].ToString(),
                    Contrasenna = reader["contrasenna"].ToString()
                };
            }
            conn.Close();

            return usuarioEncontrado;
        }
    }
}
