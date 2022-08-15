﻿using System.Data.SqlClient;


namespace ejercicioDeClase12
{
    public class UsuarioHandler : DbHandler
    {

            public List<Usuario> GetUsuarios()
            {
                List<Usuario> usuarios = new List<Usuario>();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Usuario", sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            // Me aseguro que haya filas que leer
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                 Usuario usuario = new Usuario();
                                 usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                 usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                 usuario.Nombre = dataReader["Nombre"].ToString();
                                 usuario.Apellido = dataReader["Apellido"].ToString();
                                 usuario.Contraseña = dataReader["Contraseña"].ToString();
                                 usuario.Mail = dataReader["Mail"].ToString();

                                
                                 usuarios.Add(usuario);


                            }
                            }
                        }

                        sqlConnection.Close();
                    }
                }

                return usuarios;
            }
        }

    internal class Usuarios
    {
    }
}
