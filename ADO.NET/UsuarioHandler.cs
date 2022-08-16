using System.Data;
using System.Data.SqlClient;


namespace ejercicioDeClase12
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> GetUsuarios(string nombreUsuario)
            {
                List<Usuario> usuarios = new List<Usuario>();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(
                        "SELECT * FROM Usuario where NombreUsuario = @nombreUsuario", sqlConnection))
                    {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "nombreUsuario";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(parametro);


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
        public void DeleteUsuario(int idUsuario)
            {
              try
              {
                 using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                 {
                   string queryDelete = "delete from Usuario where Id = @idUsuario";
                   SqlParameter parametro = new SqlParameter();
                   parametro.ParameterName = "idUsuario";
                   parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                   parametro.Value = idUsuario;

                    sqlConnection.Open();
                   using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                   {
                    sqlCommand.Parameters.Add(parametro);
                    sqlCommand.ExecuteNonQuery();
                   }
                    sqlConnection.Close();
                 }
              }
              catch (Exception ex)
              {
                Console.WriteLine(ex.Message);
              }    
            }
        public void UpdateUsuario(int idUsuario, string nuevoNombreUsuario)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "update Usuario set NombreUsuario = @nuevoNombreUsuario where Id = @idUsuario";
                    SqlParameter parametroNuevoNombre = new SqlParameter();
                    parametroNuevoNombre.ParameterName = "nuevoNombreUsuario";
                    parametroNuevoNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNuevoNombre.Value = nuevoNombreUsuario;

                    SqlParameter parametroIdUsuario = new SqlParameter();
                    parametroIdUsuario.ParameterName = "idUsuario";
                    parametroIdUsuario.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroIdUsuario.Value = idUsuario;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroNuevoNombre);
                        sqlCommand.Parameters.Add(parametroIdUsuario);
                        sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddUsuario(string nombre, string apellido, string nombreUsuario, string contraseña, string mail )
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryAdd = "insert into Usuario (Nombre, Apellido, NombreUsuario,Contraseña, Mail) " +
                        "values (@nombre,@apellido,@nombreUsuario,@contraseña,@mail)";
                    SqlParameter parametroNombre = new SqlParameter();
                    parametroNombre.ParameterName = "nombre";
                    parametroNombre.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNombre.Value = nombre;

                    SqlParameter parametroApellido = new SqlParameter();
                    parametroApellido.ParameterName = "apellido";
                    parametroApellido.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroApellido.Value = apellido;

                    SqlParameter parametroNombreUsuario = new SqlParameter();
                    parametroNombreUsuario.ParameterName = "nombreUsuario";
                    parametroNombreUsuario.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNombreUsuario.Value = nombreUsuario;

                    SqlParameter parametroContraseña= new SqlParameter();
                    parametroContraseña.ParameterName = "contraseña";
                    parametroContraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroContraseña.Value = contraseña;

                    SqlParameter parametroMail = new SqlParameter();
                    parametroMail.ParameterName = "mail";
                    parametroMail.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroMail.Value = mail;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroNombre);
                        sqlCommand.Parameters.Add(parametroApellido);
                        sqlCommand.Parameters.Add(parametroNombreUsuario);
                        sqlCommand.Parameters.Add(parametroContraseña);
                        sqlCommand.Parameters.Add(parametroMail);
                        sqlCommand.ExecuteScalar();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
