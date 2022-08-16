using System.Data;
using System.Data.SqlClient;

namespace ejercicioDeClase12 
{
    public class VentaHandler : DbHandler
    {

        public List<Venta> GetVenta(int idVenta)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Venta where Id = @idVenta", sqlConnection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idVenta";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = idVenta;
                    sqlCommand.Parameters.Add(parametro);
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                ventas.Add(venta);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return ventas;
        }
        public void DeleteVenta(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "delete from Venta where Id = @id";
                    SqlParameter parametroId = new SqlParameter();
                    parametroId.ParameterName = "id";
                    parametroId.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroId.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroId);
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
        public void AddVenta(string comentarios)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryAdd = "insert into Venta (Comentarios) " +
                        "values (@comentarios)";
                    SqlParameter parametroComentarios = new SqlParameter();
                    parametroComentarios.ParameterName = "comentarios";
                    parametroComentarios.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroComentarios.Value = comentarios;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroComentarios);
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
        public void UpdateVenta(int id, string nuevoComentario)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "update Venta set Comentarios = @nuevoComentario where Id = @id";
                    SqlParameter parametroComentario = new SqlParameter();
                    parametroComentario.ParameterName = "nuevoComentario";
                    parametroComentario.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroComentario.Value = nuevoComentario;

                    SqlParameter parametroId = new SqlParameter();
                    parametroId.ParameterName = "id";
                    parametroId.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroId.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroComentario);
                        sqlCommand.Parameters.Add(parametroId);
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
    }
}