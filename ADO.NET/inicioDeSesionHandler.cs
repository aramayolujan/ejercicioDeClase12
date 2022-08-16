using System.Data;
using System.Data.SqlClient;
namespace ejercicioDeClase12
{
    public class InicioDeSesionHandler : DbHandler
    {
        public List<Usuario> GetInicioDeSesion(string nombreUsuario, string contraseña)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "select * from Usuario where NombreUsuario = @nombreUsuario and Contraseña = @contrasena", sqlConnection))
                {

                    SqlParameter parametroNombreUsuario = new SqlParameter();
                    parametroNombreUsuario.ParameterName = "nombreUsuario";
                    parametroNombreUsuario.SqlDbType = SqlDbType.VarChar;
                    parametroNombreUsuario.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(parametroNombreUsuario);

                    SqlParameter parametroContraseña = new SqlParameter();
                    parametroContraseña.ParameterName = "contrasena";
                    parametroContraseña.SqlDbType = SqlDbType.VarChar;
                    parametroContraseña.Value = contraseña;
                    sqlCommand.Parameters.Add(parametroContraseña);

                    sqlConnection.Open();
                    try
                    {
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Usuario usuario = new Usuario();
                                    usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.Contraseña = dataReader["Contraseña"].ToString();
                                    usuarios.Add(usuario);
                                }
                            }

                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    

                    sqlConnection.Close();
                }
            }

            return usuarios;
        }
    }
}
