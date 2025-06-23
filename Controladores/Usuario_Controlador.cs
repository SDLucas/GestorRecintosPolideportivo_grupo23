using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Controladores
{
    public class Usuario_Controlador
    {

        public int dar_baja_usuario(int idUsuario)
        {
            int resultado;
            using (SqlConnection conexion = BaseDeDatos.Instancia.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand("sp_BajaLogicaUsuario", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_usuario", idUsuario);
                conexion.Open();
                resultado = comando.ExecuteNonQuery();
            }
            return resultado;
        }


        public Usuario verificar_datos(int dni, string password)
        {
            Usuario usuario = null;

            using (var conexion = BaseDeDatos.Instancia.ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = new SqlCommand("sp_VerificarUsuarioLogin", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                id_Usuario = (int)reader["id_Usuario"],
                                DNI_Usuario = (int)reader["DNI_Usuario"],
                                Nombre_Usuario = reader["Nombre_Usuario"].ToString(),
                                Apellido_Usuario = reader["Apellido_Usuario"].ToString(),
                                Fecha_Ingreso = Convert.ToDateTime(reader["Fecha_Ingreso"]),
                                Fecha_Nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                                pass = reader["pass"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                Id_Tipo = (int)reader["Id_Tipo"],
                                Sexo_Usuario = reader["Sexo_Usuario"].ToString()
                            };
                        }
                    }
                }
                conexion.Close();
            }

            return usuario;
        }
    }
}
