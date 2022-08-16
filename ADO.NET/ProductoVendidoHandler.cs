using System.Data;
using System.Data.SqlClient;
namespace ejercicioDeClase12
{
  
   
        public class ProductoVendidoHandler : DbHandler
        {

        public List<ProductoVendido> GetProductosVendidos(int idUsuario)
            {
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            ProductoHandler productoHandler = new ProductoHandler();

           List<Producto> prodsUsuario = productoHandler.GetProductos(idUsuario);
            foreach(Producto producto in prodsUsuario)
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(
                            "select productoVendido.Id, productoVendido.IdProducto, productoVendido.Stock, productoVendido.IdVenta " +
                            "from  ProductoVendido " +
                            "where ProductoVendido.IdProducto =  @idProducto", sqlConnection))
                    {
                        var parametro = new SqlParameter();
                        parametro.ParameterName = "idProducto";
                        parametro.SqlDbType = SqlDbType.BigInt;
                        parametro.Value = producto.Id;
                        sqlCommand.Parameters.Add(parametro);


                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            // Me aseguro que haya filas que leer
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);



                                    productosVendidos.Add(productoVendido);
                                }
                            }
                        }

                        sqlConnection.Close();
                    }
                }
            }
            

            return productosVendidos;
            ;
        }
        public void DeleteProductoVendido(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "delete from ProductoVendido where Id = @id";
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
        public void AddProductoVendido(int idProducto, int stock, int idVenta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryAdd = "insert into ProductoVendido (IdProducto, Stock, IdVenta) " +
                        "values (@idProducto,@stock,@idVenta)";
                    SqlParameter parametroIdProducto = new SqlParameter();
                    parametroIdProducto.ParameterName = "idProducto";
                    parametroIdProducto.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroIdProducto.Value = idProducto;

                    SqlParameter parametroStock = new SqlParameter();
                    parametroStock.ParameterName = "stock";
                    parametroStock.SqlDbType = System.Data.SqlDbType.Int;
                    parametroStock.Value = stock;

                    SqlParameter parametroIdVenta = new SqlParameter();
                    parametroIdVenta.ParameterName = "idVenta";
                    parametroIdVenta.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroIdVenta.Value = idVenta;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroIdProducto);
                        sqlCommand.Parameters.Add(parametroStock);
                        sqlCommand.Parameters.Add(parametroIdVenta);
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
        public void UpdateProductoVendido(int id, int nuevoStock)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryUpdate = "update ProductoVendido set Stock = @nuevoStock where Id = @id";
                    SqlParameter parametroNuevostock = new SqlParameter();
                    parametroNuevostock.ParameterName = "nuevoStock";
                    parametroNuevostock.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNuevostock.Value = nuevoStock;

                    SqlParameter parametroId = new SqlParameter();
                    parametroId.ParameterName = "id";
                    parametroId.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametroId.Value = id;

                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametroNuevostock);
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
