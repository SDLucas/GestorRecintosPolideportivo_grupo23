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
                                id_usuario = (int)reader["id_Usuario"],
                                dni_usuario = (int)reader["DNI_Usuario"],
                                nombre_usuario = reader["Nombre_Usuario"].ToString(),
                                apellido_usuario = reader["Apellido_Usuario"].ToString(),
                                fecha_ingreso = Convert.ToDateTime(reader["Fecha_Ingreso"]),
                                fecha_nacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                                pass = reader["pass"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                id_tipo = (int)reader["Id_Tipo"],
                                sexo_usuario = reader["Sexo_Usuario"].ToString()
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
