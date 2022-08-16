using System.Data;
using System.Data.SqlClient;

namespace ejercicioDeClase12
{
    public class ProductoHandler : DbHandler 
    { 
        public List<Producto> GetProductos(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "select * from Producto where IdUsuario = @idUsuario", sqlConnection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = SqlDbType.BigInt;
                    parametro.Value = idUsuario;
                    sqlCommand.Parameters.Add(parametro);


                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();

                                productos.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productos;
        }
        public void DeleteProducto(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "delete from Producto where Id = @id";
                    SqlParameter parametroIdProducto = new SqlParameter();
                    parametroIdProducto.ParameterName = "id";
                    parametroIdProducto.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroIdProducto.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroIdProducto);
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
        public void AddProducto(string descripciones, int costo, int precioVenta, int stock, int idUsuario)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryAdd = "insert into Producto (Descripciones, Costo, PrecioVenta,Stock, IdUsuario) " +
                        "values ('@descripciones',@costo,@precioVenta,@stock,@idUsuario)";
                    SqlParameter parametroDescripciones = new SqlParameter();
                    parametroDescripciones.ParameterName = "descripciones";
                    parametroDescripciones.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroDescripciones.Value = descripciones;

                    SqlParameter parametroCosto = new SqlParameter();
                    parametroCosto.ParameterName = "costo";
                    parametroCosto.SqlDbType = System.Data.SqlDbType.Money;
                    parametroCosto.Value = costo;

                    SqlParameter parametroPrecioVenta = new SqlParameter();
                    parametroPrecioVenta.ParameterName = "precioVenta";
                    parametroPrecioVenta.SqlDbType = System.Data.SqlDbType.Money;
                    parametroPrecioVenta.Value = precioVenta;

                    SqlParameter parametroStock = new SqlParameter();
                    parametroStock.ParameterName = "stock";
                    parametroStock.SqlDbType = System.Data.SqlDbType.Int;
                    parametroStock.Value = stock;

                    SqlParameter parametroIdUsuario = new SqlParameter();
                    parametroIdUsuario.ParameterName = "idUsuario";
                    parametroIdUsuario.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroIdUsuario.Value = idUsuario;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroDescripciones);
                        sqlCommand.Parameters.Add(parametroCosto);
                        sqlCommand.Parameters.Add(parametroPrecioVenta);
                        sqlCommand.Parameters.Add(parametroStock);
                        sqlCommand.Parameters.Add(parametroIdUsuario);
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
        public void UpdateProducto(int id, int nuevoPrecioVenta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "update Producto set PrecioVenta = @nuevoPrecioVenta where Id = @id";
                    SqlParameter parametroNuevoPrecioVenta = new SqlParameter();
                    parametroNuevoPrecioVenta.ParameterName = "nuevoPrecioVenta";
                    parametroNuevoPrecioVenta.SqlDbType = System.Data.SqlDbType.Money;
                    parametroNuevoPrecioVenta.Value = nuevoPrecioVenta;

                    SqlParameter parametroId = new SqlParameter();
                    parametroId.ParameterName = "id";
                    parametroId.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroId.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroNuevoPrecioVenta);
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